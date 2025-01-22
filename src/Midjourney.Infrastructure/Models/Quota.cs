using MongoDB.Bson.Serialization.Attributes;

namespace Midjourney.Infrastructure.Models;

public class Quota: DomainObject
{
    public Quota()
    {
    }
    
    /// <summary>
    ///  外部用户id
    /// </summary>
    public string OuterUserId { get; set; }
    
    /// <summary>
    /// 用户备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 每日限额
    /// </summary>
    public int DailyQuota { get; set; } = -1;
    
    /// <summary>
    /// 每月限额
    /// </summary>
    public int MonthlyQuota { get; set; } = -1;
    
    /// <summary>
    /// 今日已用
    /// </summary>
    public int UsedToday { get; set; }
    
    /// <summary>
    /// 累计使用
    /// </summary>
    public int TotalUsed { get; set; } = 0;
    
    /// <summary>
    /// 绑定可用MJ账号列表: 对应MJ InstanceId
    /// </summary>
    public List<string> BindAccounts { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime CreateTime { get; set; } = DateTime.Now;
    
    /// <summary>
    /// 更新时间
    /// </summary>
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime UpdateTime { get; set; } = DateTime.Now;
    

}