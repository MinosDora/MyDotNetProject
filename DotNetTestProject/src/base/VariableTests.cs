using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 变量
    /// </summary>
    public class VariableTests
    {
        /// <summary>
        /// 测试局部变量未初始化时即已分配内存，未赋值的局部变量不能直接访问是编译器为防止程序员粗心造成Bug而添加的错误信息
        /// </summary>
        public unsafe void Test1()
        {
            int a = 10;
            int b;
            int c = 20;
            Console.WriteLine((int)&a);     //-1233195472
            Console.WriteLine((int)&b);     //-1233195480
            Console.WriteLine((int)&c);     //-1233195488
            Console.WriteLine(*(&b));       //0
        }
    }
}