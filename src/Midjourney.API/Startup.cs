﻿// Midjourney Proxy - Proxy for Midjourney's Discord, enabling AI drawings via API with one-click face swap. A free, non-profit drawing API project.
// Copyright (C) 2024 trueai.org

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

// Additional Terms:
// This software shall not be used for any illegal activities. 
// Users must comply with all applicable laws and regulations,
// particularly those related to image and video processing. 
// The use of this software for any form of illegal face swapping,
// invasion of privacy, or any other unlawful purposes is strictly prohibited. 
// Violation of these terms may result in termination of the license and may subject the violator to legal action.

global using Midjourney.Infrastructure;
global using Midjourney.Infrastructure.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Midjourney.Infrastructure.Data;
using Midjourney.Infrastructure.Options;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;
using Midjourney.Infrastructure.Swagger;
using Nacos.AspNetCore.V2;

namespace Midjourney.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // 启动时，优先初始化全局配置项
            var configSec = Configuration.GetSection("mj");
            var configOpt = configSec.Get<ProxyProperties>();
            services.Configure<ProxyProperties>(configSec);

            var ipSec = Configuration.GetSection("IpRateLimiting");
            var ipRateOpt = ipSec.Get<IpRateLimitingOptions>();
            services.Configure<IpRateLimitingOptions>(ipSec);

            var ipBlackSec = Configuration.GetSection("IpBlackRateLimiting");
            var ipBlackOpt = ipBlackSec.Get<IpBlackRateLimitingOptions>();
            services.Configure<IpBlackRateLimitingOptions>(ipBlackSec);

            var setting = LiteDBHelper.SettingStore.Get(Constants.DEFAULT_SETTING_ID);
            if (setting == null)
            {
                setting = new Setting
                {
                    Id = Constants.DEFAULT_SETTING_ID,
                    IpRateLimiting = ipRateOpt,
                    IpBlackRateLimiting = ipBlackOpt,
                    EnableRegister = true,
                    EnableGuest = true,
                    RegisterUserDefaultDayLimit = -1,
                    GuestDefaultDayLimit = -1,

                    AccountChooseRule = configOpt.AccountChooseRule,
                    BaiduTranslate = configOpt.BaiduTranslate,
                    CaptchaNotifyHook = configOpt.CaptchaNotifyHook,
                    CaptchaNotifySecret = configOpt.CaptchaNotifySecret,
                    CaptchaServer = configOpt.CaptchaServer,
                    NgDiscord = configOpt.NgDiscord,
                    NotifyHook = configOpt.NotifyHook,
                    NotifyPoolSize = configOpt.NotifyPoolSize,
                    Openai = configOpt.Openai,
                    Proxy = configOpt.Proxy,
                    TranslateWay = configOpt.TranslateWay,
                    Smtp = configOpt.Smtp
                };
                LiteDBHelper.SettingStore.Save(setting);

                // 等待 1s
                Thread.Sleep(1 * 1000);
            }

            GlobalConfiguration.Setting = setting;

            // mongo 配置
            if (!string.IsNullOrWhiteSpace(setting.MongoDefaultConnectionString)
                && !string.IsNullOrWhiteSpace(setting.MongoDefaultDatabase))
            {
                var success = MongoHelper.Verify();
                if (success)
                {
                    setting.IsMongo = true;
                }
                else
                {
                    setting.IsMongo = false;
                }
            }
            else
            {
                setting.IsMongo = false;
            }

            // 更新数据库
            LiteDBHelper.SettingStore.Save(setting);
            GlobalConfiguration.Setting = setting;

            // 缓存
            services.AddMemoryCache();

            // 是否为演示模式
            var isDemoMode = Configuration.GetSection("Demo").Get<bool?>();
            if (isDemoMode != true)
            {
                if (bool.TryParse(Environment.GetEnvironmentVariable("DEMO"), out var demo) && demo)
                {
                    isDemoMode = demo;
                }
            }
            GlobalConfiguration.IsDemoMode = isDemoMode;

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<WorkContext>();

            // API 异常过滤器
            // API 方法/模型过滤器
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomLogicExceptionFilterAttribute>();
                options.Filters.Add<CustomActionFilterAttribute>();
            }).AddJsonOptions(options =>
            {
                // 配置枚举序列化为字符串
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // 添加授权服务
            services.AddAuthorization();

            // 自定义配置 API 行为选项
            // 配置 api 视图模型验证 400 错误处理，需要在 AddControllers 之后配置
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var error = context.ModelState.Values.FirstOrDefault()?.Errors?.FirstOrDefault()?.ErrorMessage ?? "参数异常";
                    Log.Logger.Warning("参数异常 {@0} - {@1}", context.HttpContext?.Request?.GetUrl() ?? "", error);
                    return new JsonResult(Result.Fail(error));
                };
            });

            // 注册 HttpClient
            services.AddHttpClient();

            // 注册 Midjourney 服务
            services.AddMidjourneyServices(setting);

            // 注册 Discord 账号初始化器
            services.AddSingleton<DiscordAccountInitializer>();
            services.AddHostedService(provider => provider.GetRequiredService<DiscordAccountInitializer>());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Midjourney API", Version = "v1" });

                // c.DocumentFilter<SwaggerPrefixFilter>();  // 添加这一行


                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "在下框中输入请求头中需要添加的授权 Authorization: {Token}",
                    // Name = "Authorization", // 或者 "Mj-Api-Secret" 视具体需求而定
                    Name = "Mj-Api-Secret", // 或者 "Mj-Api-Secret" 视具体需求而定
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        new string[] { }
                    }
                });

                var xmls = new string[] { "Midjourney.Infrastructure.xml" };
                foreach (var xmlModel in xmls)
                {
                    var baseDirectory = AppContext.BaseDirectory;
                    if (!File.Exists(Path.Combine(baseDirectory, xmlModel)))
                    {
                        baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
                    }

                    var xmlSubPath = Path.Combine(baseDirectory, xmlModel);
                    if (File.Exists(xmlSubPath))
                    {
                        c.IncludeXmlComments(xmlSubPath, true);
                    }
                }

                // 当前程序集名称
                var assemblyMame = Assembly.GetExecutingAssembly().GetName().Name;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{assemblyMame}.xml");
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath, true);
                }
            });
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin() // 允许的域名
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // 服务注册
            services.AddNacosAspNet(Configuration, "nacos");

        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() || GlobalConfiguration.IsDemoMode == true || GlobalConfiguration.Setting?.EnableSwagger == true)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //TODO: (禁用静态文件)


            // app.UseDefaultFiles(); // 启用默认文件（index.html）
            // app.UseStaticFiles(); // 配置提供静态文件

            app.UseCors(builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
                // builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true);
            });
            // app.UseCors("MyPolicy");

            app.UseRouting();

            // 使用自定义中间件
            app.UseMiddleware<SimpleAuthMiddleware>();

            // 限流
            app.UseMiddleware<RateLimitingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // 添加 统一路由前缀
                // var group = endpoints.MapGroup("/midjourney");
                // group.MapControllers();

                endpoints.MapControllers();
            });
        }
    }
}