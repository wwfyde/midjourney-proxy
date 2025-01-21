namespace Midjourney.Infrastructure.Dto
{
    /// <summary>
    /// 首页信息
    /// </summary>
    public class TotalUsageDTO
    {


        /// <summary>
        /// 本日用量
        /// </summary>
        public int TodayUsage { get; set; }

        /// <summary>
        /// 本周用量
        /// </summary>
        public int WeekUsage { get; set; }

        /// <summary>
        /// 本月用量
        /// </summary>
        public int MonthUsage { get; set; }


        /// <summary>
        /// 最近七天用量
        /// </summary>
        public int Last7DaysUsage { get; set; }

        /// <summary>
        /// 本日用户
        /// </summary>
        public int TodayUser { get; set; }

        /// <summary>
        /// 本周用户
        /// </summary>
        public int WeekUser { get; set; }

        /// <summary>
        /// 本月用户
        /// </summary>
        public int MonthUser { get; set; }

        /// <summary>
        /// 最近七天用户
        /// </summary>
        public int Last7DaysUser { get; set; }



    }
}