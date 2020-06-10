using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 对象内存模型
    /// </summary>
    public class ObjectMemoryTests
    {
        /// <summary>
        /// 测试对象的内存布局
        /// </summary>
        public void Test1()
        {
            //                                  内存地址               同步块索引        类型对象指针      字段MyNum的值
            MyClass obj1 = new MyClass(512);    //0x000001F5445A2D70  0000000000000000 00007ffc1b8d5e70 0000000000000200
            MyClass obj2 = new MyClass(1024);   //0x000001F5445A2D88  0000000100000000 00007ffc1b8d5e70 0000000000000400
            MyClass obj3 = new MyClass(2048);   //0x000001F5445A2DA0  0000000000000000 00007ffc1b8d5e70 0000000000000800

            lock (obj2)
            {
                Console.WriteLine();    //在这里设置个断点，然后通过调式-窗口-内存-内存1打开内存窗口
                                        //然后右键选择8字节整型，十六进制显示，Unicode文本，然后输入obj1即可查看该变量的内存地址及对应的值
            }
        }
        public class MyClass
        {
            public static int StaticNum = 0b10101010;
            public int MyNum;
            public MyClass(int num) => MyNum = num;
        }
    }
}