using System;
using System.Runtime.InteropServices;

namespace DotNetTestProject
{
    /// <summary>
    /// 互操作
    /// </summary>
    public class InteropTests
    {
        [DllImport("InteropTestProject.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int Sum(int a, int b);
        /// <summary>
        /// 测试C#传递数值给C++并返回
        /// </summary>
        public void Test1()
        {
            var result = Sum(10, 20);
            Console.WriteLine($"10 + 20 = {result}");
        }

        [DllImport("InteropTestProject.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        extern static int GetLength([MarshalAs(UnmanagedType.LPStr)] string str);
        /// <summary>
        /// 测试C#传递字符串给C++并返回
        /// </summary>
        public void Test2()
        {
            string str = "hello";
            Console.WriteLine($@"""{str}""'s length is:{GetLength(str)}");
        }
    }
}