using System.Net;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Midjourney.Infrastructure.Data;
using Midjourney.Infrastructure.Dto;
using Midjourney.Infrastructure.Models;
using MongoDB.Driver.Linq;
using Serilog;

namespace Midjourney.API.Controllers
{
    /// <summary>
    /// 控制器用于获取使用情况
    /// </summary>
    [ApiController]
    [Route("mj/usage")]
    public class UsageController : ControllerBase
    {
        private readonly string _ip;
        private readonly WorkContext _workContext;



        public UsageController(
            IHttpContextAccessor httpContextAccessor,
            WorkContext workContext)
        {
            _workContext = workContext;
            var user = _workContext.GetUser();
            // 如果非演示模式、未开启访客，如果没有登录，直接返回 403 错误
            if (GlobalConfiguration.IsDemoMode != true
                && GlobalConfiguration.Setting.EnableGuest != true)
            {
                if (user == null)
                {
                    // 如果是普通用户, 并且不是匿名控制器，则返回 403
                    httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    httpContextAccessor.HttpContext.Response.WriteAsync("未登录");
                    Log.Warning("未登录");
                    return;
                }
            }

            _ip = httpContextAccessor.HttpContext.Request.GetIP();

        }

        /// <summary>
        /// 获取当前用户的使用情况
        /// </summary>
        [HttpGet("current-user")]
        public UserUsageDTO CurrentUsage()
        {
            // var userId = _workContext.UserId;
            // var usage = await _workContext.GetUsage(userId);
            var outerUserId = _workContext.GetOuterUserId();

            // 从数据库中获取用户的使用情况
            // var now = new DateTimeOffset(DateTime.Now.Date).ToUnixTimeMilliseconds();
            var now = DateTimeOffset.Now;

            var startOfDay = new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();
            // var startOfWeek = now.AddDays(-(int)now.DayOfWeek).Date.ToUnixTimeMilliseconds();
            var startOfWeek = new DateTimeOffset(now.AddDays(-(int)now.DayOfWeek).Date).ToUnixTimeMilliseconds();
            // var startOfMonth = new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();

            var startOfMonth = new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();
            var startOf7Days = new DateTimeOffset(now.AddDays(-7).Date).ToUnixTimeMilliseconds();

            // var dayUsage = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId == outerUserId)
            //     
            //     .Count(x => x.SubmitTime >= now);
            var dayUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.OuterUserId == outerUserId && x.SubmitTime >= startOfDay);

            var weekUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.OuterUserId == outerUserId && x.SubmitTime >= startOfWeek);
            var monthUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.OuterUserId == outerUserId && x.SubmitTime >= startOfMonth);
            var last7DaysUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.OuterUserId == outerUserId && x.SubmitTime >= startOf7Days);



            var usage = new UserUsageDTO
            {
                OuterUserId = outerUserId,
                DayUsage = dayUsage,
                WeekUsage = weekUsage,
                MonthUsage = monthUsage,
                Last7DaysUsage = last7DaysUsage,
                DayQuota = 0 // Usage = usage

                // Usage = usage
            };
            return usage;
        }

        /// <summary>
        /// 获取整体使用情况
        /// </summary>
        [HttpGet("total")]
        public TotalUsageDTO TotalUsage()
        {
            var now = DateTimeOffset.Now;
            var startOfToday = new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();
            var startOfWeek = new DateTimeOffset(now.AddDays(-(int)now.DayOfWeek).Date).ToUnixTimeMilliseconds();
            var startOfMonth = new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();
            var startOf7Days = new DateTimeOffset(now.AddDays(-7).Date).ToUnixTimeMilliseconds();


            var todayUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.SubmitTime >= startOfToday);
            var weekUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.SubmitTime >= startOfWeek);
            var monthUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.SubmitTime >= startOfMonth);
            var last7DaysUsage = (int)DbHelper.Instance.TaskStore.Count(x => x.SubmitTime >= startOf7Days);

            var todayUser = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null).Count(x => x.SubmitTime >= startOfToday);
            var weekUser = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null).Count(x => x.SubmitTime >= startOfWeek);
            var monthUser = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null).Count(x => x.SubmitTime >= startOfMonth);
            var last7DaysUser = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null).Count(x => x.SubmitTime >= startOf7Days);

            var totalUsage = new TotalUsageDTO
            {
                TodayUsage = todayUsage,
                WeekUsage = weekUsage,
                MonthUsage = monthUsage,
                Last7DaysUsage = last7DaysUsage,
                TodayUser = todayUser,
                WeekUser = weekUser,
                MonthUser = monthUser,
                Last7DaysUser = last7DaysUser,
            };

            return totalUsage;
        }


        /// <summary>
        /// 获取按用户分组的使用情况
        /// </summary>
        [HttpGet("user-group")]
        public IActionResult GroupUsage()
        {
            var now = DateTimeOffset.Now;
            var startOfDay = new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();
            var startOfWeek = new DateTimeOffset(now.AddDays(-(int)now.DayOfWeek).Date).ToUnixTimeMilliseconds();
            var startOfMonth = new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset).ToUnixTimeMilliseconds();

            var tasks = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null).ToList();

            var groupUsage = tasks
                .GroupBy(x => x.OuterUserId)
                .Select(g => new
                {
                    OuterUserId = g.Key,
                    DayUsage = g.Count(x => x.SubmitTime >= startOfDay),
                    WeekUsage = g.Count(x => x.SubmitTime >= startOfWeek),
                    MonthUsage = g.Count(x => x.SubmitTime >= startOfMonth)
                })
                .ToList();

            return Ok(groupUsage);
        }

        /// <summary>
        /// 根据DateRangePicker获取使用情况
        /// </summary>
        [HttpPost("date-range")]
        public IActionResult DateRangeUsage([FromBody] DateRangeDTO dateRange)
        {

            if (string.IsNullOrEmpty(dateRange.StartDate) || string.IsNullOrEmpty(dateRange.EndDate))
            {
                return BadRequest("开始时间和结束时间不能为空");
            }

            // 解析日期字符串为 DateTime
            if (!DateTime.TryParse(dateRange.StartDate, out DateTime startDate) ||
                !DateTime.TryParse(dateRange.EndDate, out DateTime endDate))
            {
                return BadRequest("日期格式无效");
            }
            var startTimestamp = new DateTimeOffset(startDate).ToUnixTimeMilliseconds();
            var endTimestamp = new DateTimeOffset(endDate).ToUnixTimeMilliseconds();
            Log.Warning("开始时间：{0}，结束时间：{1}", startDate, endDate);
            Log.Warning("开始时间：{0}，结束时间：{1}", startTimestamp, endTimestamp);

            var tasks = DbHelper.Instance.TaskStore.Where(x => x.OuterUserId != null && x.SubmitTime >= startTimestamp && x.SubmitTime <= endTimestamp).ToList();

            var groupUsage = tasks
                .GroupBy(x => x.OuterUserId)

                .Select(g => new
                {
                    User = g.Key,
                    Usage = g.Count()
                    // DayUsage = g.Count(x => x.SubmitTime >= startTimestamp)
                })
                .ToList();

            return Ok(groupUsage);

        }


    }

}
