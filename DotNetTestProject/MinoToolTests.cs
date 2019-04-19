using System;
using MinoTool;

namespace DotNetTestProject
{
    public static class MinoToolTests
    {
        /// <summary>
        /// 计时器工具测试类
        /// </summary>
        public static class StopwatchUtilTests
        {
            /// <summary>
            /// 测试生成计时器
            /// </summary>
            public static void CreateStopwatchTest()
            {
                using (StopwatchUtil.CreateStopwatch())
                {

                }
            }
        }

        /// <summary>
        /// 时间工具测试类
        /// </summary>
        public static class DateTimeUtilTests
        {
            /// <summary>
            /// 测试DateTime转短时间戳
            /// </summary>
            public static void DateTimeToTimeStampTest()
            {
                Console.WriteLine(DateTimeUtil.DateTimeToTimeStamp(DateTime.Now));
            }

            /// <summary>
            /// 测试DateTime转长时间戳
            /// </summary>
            public static void DateTimeToLongTimeStampTest()
            {
                Console.WriteLine(DateTimeUtil.DateTimeToLongTimeStamp(DateTime.Now));
            }

            /// <summary>
            /// 测试短时间戳转DateTime
            /// </summary>
            public static void TimeStampToDateTimeTest()
            {
                Console.WriteLine(DateTimeUtil.TimeStampToDateTime(DateTimeUtil.DateTimeToTimeStamp(DateTime.Now)));
            }

            /// <summary>
            /// 测试长时间戳转DateTime
            /// </summary>
            public static void LongTimeStampToDateTimeTest()
            {
                Console.WriteLine(DateTimeUtil.LongTimeStampToDateTime(DateTimeUtil.DateTimeToLongTimeStamp(DateTime.Now)));
            }
        }
    }
}