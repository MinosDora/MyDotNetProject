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
        private class MyClass
        {
            public static int StaticNum = 0b10101010;
            public int MyNum;
            public MyClass(int num) => MyNum = num;
        }

        /// <summary>
        /// 测试堆内存上的对象在获取一次哈希值时会将其哈希值保存在同步索引块上，在获取锁后会回复
        /// </summary>
        public void Test2()
        {
            MyClass1 myClass = new MyClass1();
            int hashCode = myClass.GetHashCode();
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(hashCode)));
            //98-80-BF-02
            //1001 1000 1000 0000 1011 1111 0000 0010
            unsafe
            {
                fixed (long* p = &myClass.myNum)
                {
                    Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(*(p - 2))));
                    //00-00-00-00-98-80-BF-0E
                    //1001 1000 1000 0000 1011 1111 0000 1110

                    //TODO
                    //* (p - 2) = 0;
                    //Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(myClass.GetHashCode())));
                }
            }
            lock (myClass)
            {
                unsafe
                {
                    fixed (long* p = &myClass.myNum)
                    {
                        Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(*(p - 2))));
                        //00-00-00-00-01-00-00-08
                        //0001 0000 0000 0000 0000 0000 1000
                    }
                }
            }
        }
        private class MyClass1
        {
            public long myNum;
        }
    }
}