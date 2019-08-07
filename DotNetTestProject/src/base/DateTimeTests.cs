using System;

namespace DotNetTestProject
{
    /// <summary>
    /// DateTime
    /// </summary>
    public class DateTimeTests
    {
        /// <summary>
        /// 测试DateTime默认值
        /// </summary>
        public void Test1()
        {
            Console.WriteLine(default(DateTime)); //0001 / 1 / 1 0:00:00
        }
    }
}