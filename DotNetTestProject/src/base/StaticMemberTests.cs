using System;
using System.Threading;

namespace DotNetTestProject
{
    /// <summary>
    /// 静态成员
    /// </summary>
    public class StaticMemberTests
    {
        /// <summary>
        /// 测试CLR保证静态构造函数线程安全，静态构造函数的耗时操作会阻塞所有正在调用该静态构造函数的线程
        /// </summary>
        public void Test1()
        {
            Thread thread = new Thread(() =>
            {
                MyClass.MyFunc();
            });
            thread.Start();
            MyClass.MyFunc();
            Console.WriteLine($"The main thread Id is {Thread.CurrentThread.ManagedThreadId}.");
            //MyClass's static constructor called, Thread Id is 1.
            //MyFunc called, Thread Id is 1.
            //The main thread Id is 1.
            //MyFunc called, Thread Id is 3.
        }

        public class MyClass
        {
            static MyClass()
            {
                Console.WriteLine($"MyClass's static constructor called, Thread Id is {Thread.CurrentThread.ManagedThreadId}.");
                Thread.Sleep(500);
            }

            public static void MyFunc()
            {
                Console.WriteLine($"MyFunc called, Thread Id is {Thread.CurrentThread.ManagedThreadId}.");
            }
        }
    }
}