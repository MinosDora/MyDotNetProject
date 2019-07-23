using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 垃圾回收
    /// </summary>
    public class GCTests
    {
        /// <summary>
        /// 测试垃圾回收时执行析构函数的时机
        /// </summary>
        public unsafe void Test1()
        {
            MyClass myClass = new MyClass();
            myClass = null;
            GC.Collect();
            Console.WriteLine("GC.Collect called.");
            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC.WaitForPendingFinalizers called.");
        }
        private class MyClass
        {
            public int MyNum;
            ~MyClass()
            {
                Console.WriteLine("MyClass's Finalizer called.");
            }
        }
    }
}