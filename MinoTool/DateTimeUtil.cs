using System;

namespace MinoTool
{
    /// <summary>
    /// 时间工具类
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>
        /// Unix时间戳开始时间
        /// </summary>
        private static DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// DateTime转换为Unix时间戳，单位：秒，10位
        /// </summary>
        /// <param name="dateTime"> DateTime格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static long DateTimeToTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalSeconds;
        }

        /// <summary>
        /// DateTime转换为Unix时间戳，单位：毫秒，13位
        /// </summary>
        /// <param name="dateTime"> DateTime格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static long DateTimeToLongTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalMilliseconds;
        }

        /// <summary>
        /// 10位Unix时间戳转换为DateTime
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>DateTime</returns>
        public static DateTime TimeStampToDateTime(long timeStamp)
        {
            return timeStampStartTime.AddSeconds(timeStamp).ToLocalTime();
        }

        /// <summary>
        /// 13位Unix时间戳格式转换为DateTime
        /// </summary>
        /// <param name="longTimeStamp">Unix时间戳格式</param>
        /// <returns>DateTime</returns>
        public static DateTime LongTimeStampToDateTime(long longTimeStamp)
        {
            return timeStampStartTime.AddMilliseconds(longTimeStamp).ToLocalTime();
        }
    }
}