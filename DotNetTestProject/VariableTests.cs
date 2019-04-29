using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 变量
    /// </summary>
    public class VariableTests
    {
        /// <summary>
        /// 测试局部变量未初始化时即已分配内存
        /// </summary>
        public unsafe void Test1()
        {
            int a = 10;
            int b;
            int c = 20;
            Console.WriteLine((int)&a);
            Console.WriteLine((int)&b);
            Console.WriteLine((int)&c);
            Console.WriteLine(*(&b));
        }
    }
}