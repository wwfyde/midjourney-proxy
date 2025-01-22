using System.Net;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Midjourney.Infrastructure.Data;
using Midjourney.Infrastructure.StandardTable;
using MongoDB.Driver;
using Serilog;

namespace Midjourney.API.Controllers
{

    /// <summary>
    /// 配额管理
    /// </summary>
    [ApiController]
    [Route("mj/quota")]
    public class QuotaController : ControllerBase
    {
        private readonly WorkContext _workContext;
        private readonly string _ip;

        public QuotaController(
            WorkContext workContext,
            IHttpContextAccessor context)
        {
            _workContext = workContext;

            var user = _workContext.GetUser();
            if (user == null)
            {
                // 如果是普通用户, 并且不是匿名控制器，则返回 403
                HttpContext.Response.StatusCode = 403;
                HttpContext.Response.WriteAsync("未登录");
                return;
            }
            // else
            // {
            //     // 如果是普通用户, 并且不是匿名控制器，则返回 403
            //     HttpContext.Response.StatusCode = 403;
            // }

            // 普通用户，无法登录管理后台，演示模式除外
            // 判断当前用户如果是普通用户
            // 并且不是匿名控制器时
            // if (user?.Role != EUserRole.ADMIN)
            // {
            //     var endpoint = context.HttpContext.GetEndpoint();
            //     var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;
            //     if (!allowAnonymous && GlobalConfiguration.IsDemoMode != true)
            //     {
            //         // 如果是普通用户, 并且不是匿名控制器，则返回 401
            //         context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //         context.HttpContext.Response.WriteAsync("Forbidden: User is not admin.");
            //         return;
            //     }
            // }

            _ip = context.HttpContext?.Request.GetIP();

        }

        /// <summary>
        /// 新建或编辑配额规则
        /// </summary>
        [HttpPost("")]
        public Result CreateQuota([FromBody] Quota quota)
        {
            // TODO
            // quota.Id = Guid.NewGuid().ToString();
            // quota.CreateTime = DateTime.Now;
            if (string.IsNullOrWhiteSpace(quota.Id))
            {
                quota.Id = Guid.NewGuid().ToString();
                Log.Warning("新建ID {0}, OuterUserId: {1}", quota.Id, quota.OuterUserId);
                if (string.IsNullOrWhiteSpace(quota.OuterUserId))
                {
                    throw new LogicException("OuterUserId 不能为空");
                }
                quota.CreateTime = DateTime.Now;

            }
            else
            {
                var model = DbHelper.Instance.QuotaStore.Get(quota.Id);
                if (model == null)
                {
                    throw new LogicException("配额规则不存在");
                }
                quota.CreateTime = model.CreateTime;
                if (quota.TotalUsed == 0)
                {
                    quota.TotalUsed = model.TotalUsed;
                }

                if (string.IsNullOrWhiteSpace(quota.OuterUserId))
                {
                    quota.OuterUserId = model.OuterUserId;
                }
                
            }

            quota.UpdateTime = DateTime.Now;
            DbHelper.Instance.QuotaStore.Save(quota);
            
            // TODO 清除缓存
            
            return Result.Ok();
        }
        
        // /// <summary>
        // /// 编辑配额规则
        // /// </summary>
        // [HttpPut("{id}")]
        // public Result UpdateQuota(string id, [FromBody] Quota quota)
        // {
        //     var model = DbHelper.Instance.QuotaStore.Get(id);
        //     if (model == null)
        //     {
        //         throw new LogicException("配额规则不存在");
        //     }
        //     model.OuterUserId = quota.OuterUserId;
        //     model.Remark = quota.Remark;
        //     model.DailyQuota = quota.DailyQuota;
        //     
        //     
        //     model.UsedToday = quota.UsedToday;
        //     model.BindAccounts = quota.BindAccounts;
        //     model.UpdateTime = DateTime.Now;
        //     DbHelper.Instance.QuotaStore.Update(model);
        //     
        //     // TODO 清除缓存
        //     
        //     return Result.Ok();
        // }

        /// <summary>
        /// 分页查查看所有配额规则
        /// </summary>
        [HttpPost("quotas")]
        public ActionResult<StandardTableResult<Quota>> GetQuotas([FromBody] StandardTableParam<Quota> request)
        {
            var user = _workContext.GetUser();

            var page = request.Pagination;
            if (page.PageSize > 100)
            {
                page.PageSize = 100;
            }
            var sort = request.Sort;
            var param = request.Search;
            Log.Warning("param {@0}", param);
            Log.Warning("request {@0}", request);

            var list = new List<Quota>();
            var count = 0;

            if (GlobalConfiguration.Setting.IsMongo)
            {
                var coll = MongoHelper.GetCollection<Quota>().AsQueryable();
                var query = coll
                    .WhereIf(!string.IsNullOrWhiteSpace(param.OuterUserId), c => c.OuterUserId.Contains(param.OuterUserId))
                    // .WhereIf(param.Enable.HasValue, c => c.Enable == param.Enable)
                    .WhereIf(!string.IsNullOrWhiteSpace(param.Remark), c => c.Remark.Contains(param.Remark));
            
                count = query.Count();
                list = query
                    .OrderByIf(nameof(Quota.UsedToday).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.UsedToday, sort.Reverse)
                    .OrderByIf(nameof(Quota.Remark).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.Remark, sort.Reverse)
                    .OrderByIf(string.IsNullOrWhiteSpace(sort.Predicate), c => c.Remark, false)
                    .Skip((page.Current - 1) * page.PageSize)
                    .Take(page.PageSize)
                    .ToList();
                var data = list.ToTableResult(request.Pagination.Current, request.Pagination.PageSize, count);
            
                return Ok(data);
            }
            else
            {
                var query = LiteDBHelper.QuotaStore.GetCollection().Query()
                    .WhereIf(!string.IsNullOrWhiteSpace(param.OuterUserId), c => c.OuterUserId.Contains(param.OuterUserId))
                    // .WhereIf(!string.IsNullOrWhiteSpace(param.ChannelId), c => c.ChannelId == param.ChannelId)
                    // .WhereIf(param.Enable.HasValue, c => c.Enable == param.Enable)
                    .WhereIf(!string.IsNullOrWhiteSpace(param.Remark), c => c.Remark.Contains(param.Remark));

                count = query.Count();
                list = query
                    .OrderByIf(nameof(Quota.UsedToday).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.UsedToday, sort.Reverse)
                    .OrderByIf(nameof(Quota.DailyQuota).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.DailyQuota, sort.Reverse)
                    .OrderByIf(nameof(Quota.Remark).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.Remark, sort.Reverse)
                    .OrderByIf(nameof(Quota.OuterUserId).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.OuterUserId, sort.Reverse)
                    .OrderByIf(nameof(Quota.CreateTime).Equals(sort.Predicate, StringComparison.OrdinalIgnoreCase), c => c.CreateTime, sort.Reverse)
                    .OrderByIf(string.IsNullOrWhiteSpace(sort.Predicate), c => c.UpdateTime, true)
                    // .OrderBy(c => c.OuterUserId)
                    .Skip((page.Current - 1) * page.PageSize)
                    .Limit(page.PageSize)
                    .ToList();
                // foreach (var item in list)
                // {
                //     item.BindAccounts = null;
                //     item.CreateTime = null;
                //     item.UpdateTime = null;
                // }
                var data = list.ToTableResult(request.Pagination.Current, request.Pagination.PageSize, count);
                Log.Warning("data {@0}", data);

                return Ok(data);
            }

            


            // var data = list.ToTableResult(request.Pagination.Current, request.Pagination.PageSize, count);
            //
            // return Ok(data);


        }

        /// <summary>
        /// 删除某条配额规则
        /// </summary>
        [HttpDelete("quotas/{id}")]
        public Result DeleteQuota(string id)
        {
            DbHelper.Instance.QuotaStore.Delete(id);
            return Result.Ok();
        }
        
        /// <summary>
        /// 获取用户当前配额
        /// </summary>
        [HttpGet("quota/current")]
        public ActionResult<Quota> GetQuota()
        {
            var outerUserId = _workContext.GetOuterUserId();
            var quota = DbHelper.Instance.QuotaStore.GetByOuterUserId(outerUserId);
            if (quota == null)
            {
                return NotFound();
            }
            return Ok(quota);
        }
        
        /// <summary>
        /// 按用户ID获取配额
        /// </summary>
        [HttpGet("quota/{outerUserId}")]
        public ActionResult<Quota> GetQuota(string outerUserId )
        {
            var quota = DbHelper.Instance.QuotaStore.GetByOuterUserId(outerUserId);
            if (quota == null)
            {
                return NotFound();
            }
            return Ok(quota);
        }

    }
}