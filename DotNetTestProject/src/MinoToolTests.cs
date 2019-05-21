using System;
using System.Threading;
using MinoTool;

namespace DotNetTestProject
{
    public static class MinoToolTests
    {
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

        /// <summary>
        /// 枚举工具测试类
        /// </summary>
        public static class EnumUtilTests
        {
            /// <summary>
            /// 测试获取枚举值名称
            /// </summary>
            public static void GetNameTest()
            {
                Console.WriteLine(EnumUtil.GetName(MyEnum.MyEnum2));
            }
            /// <summary>
            /// 测试获取枚举值
            /// </summary>
            public static void GetEnumTest()
            {
                Console.WriteLine(EnumUtil.GetEnum<MyEnum>("MyEnum2"));
            }
            /// <summary>
            /// 测试获取枚举数
            /// </summary>
            public static void GetValueTest()
            {
                Console.WriteLine(EnumUtil.GetValue<MyEnum, int>("MyEnum2"));
            }
            public enum MyEnum
            {
                MyEnum1,
                MyEnum2,
                MyEnum3,
            }
        }

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
                    Thread.Sleep(100);
                }
            }
        }
    }
}