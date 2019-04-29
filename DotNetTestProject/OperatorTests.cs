using System;
using System.Runtime.InteropServices;

namespace DotNetTestProject
{
    /// <summary>
    /// 运算符
    /// </summary>
    public class OperatorTests
    {
        /// <summary>
        /// 测试sizeof(T)和Marshal.SizeOf()区别
        /// </summary>
        public unsafe void Test1()
        {
            Console.WriteLine(sizeof(int));
            Console.WriteLine(Marshal.SizeOf<int>());
            Console.WriteLine(Marshal.SizeOf(typeof(int*)));
        }
    }
}