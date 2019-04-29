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
        public void Test1()
        {
            Console.WriteLine(sizeof(int));
            Console.WriteLine(Marshal.SizeOf<int>());
            Console.WriteLine(typeof(int*));
            Console.WriteLine(Marshal.SizeOf(typeof(int*)));
        }

        /// <summary>
        /// 测试位移运算
        /// </summary>
        public void Test2()
        {
            Console.WriteLine(BitConverter.IsLittleEndian);
            int num = -1;
            Console.WriteLine(string.Join("", BitConverter.GetBytes(1)));
            Console.WriteLine(num << 1);
            Console.WriteLine(string.Join("", BitConverter.GetBytes(num - 1)));
        }
    }
}