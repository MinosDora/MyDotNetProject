using System;
using System.Diagnostics.Contracts;

namespace DotNetTestProject
{
    /// <summary>
    /// 协定
    /// </summary>
    public class ContractTests
    {
        /// <summary>
        /// 测试代码协定，需要定义符号CONTRACTS_FULL
        /// </summary>
        public void Test1()
        {
            Console.WriteLine(MyFunc(0));
            Console.WriteLine("Test Func End.");  //忽略代码协定时可继续执行
        }
        private static int MyFunc(int a)
        {
            Contract.EnsuresOnThrow<Exception>(Contract.Result<int>() < 0);  //协定方法返回值小于0
            a = a + 1;
            return a;
        }
    }
}