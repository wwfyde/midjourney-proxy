namespace Midjourney.Infrastructure.Dto
{
    /// <summary>
    /// 首页信息
    /// </summary>
    public class UserUsageDTO
    {
        /// <summary>
        /// 外部用户ID
        /// </summary>
        public string OuterUserId { get; set; }

        /// <summary>
        /// 本日用量
        /// </summary>
        public int DayUsage { get; set; }

        /// <summary>
        /// 本周用量
        /// </summary>
        public int WeekUsage { get; set; }

        /// <summary>
        /// 本月用量
        /// </summary>
        public int MonthUsage { get; set; }

        /// <summary>
        /// 日限额
        /// </summary>
        public int DayQuota { get; set; }

        /// <summary>
        /// 最近七天用量
        /// </summary>
        public int Last7DaysUsage { get; set; }

    }
}