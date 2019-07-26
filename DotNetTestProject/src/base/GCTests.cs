using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 垃圾回收
    /// </summary>
    public class GCTests
    {
        /// <summary>
        /// 测试垃圾回收时执行析构函数的时机，需要在Release模式下运行
        /// </summary>
        public void Test1()
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
            ~MyClass()
            {
                Console.WriteLine("MyClass's Finalizer called.");
            }
        }
    }
}