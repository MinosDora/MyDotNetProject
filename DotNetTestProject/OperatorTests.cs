using System;
using System.Reflection;
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
            Console.WriteLine(Convert.ToString(num, 2));
            Console.WriteLine(num << 1);
            Console.WriteLine(Convert.ToString(num << 1, 2));
        }

        /// <summary>
        /// 测试前缀/后缀递增运算
        /// </summary>
        public void Test3()
        {
            int num = 10;
            num = ++num + num++ * 10;  //121：11 + 11 * 10
            Console.WriteLine(num);
            num = 10;
            Console.WriteLine(++num + 10);
        }

        /// <summary>
        /// 测试标识符使用@符号的情况
        /// </summary>
        public void Test4()
        {
            int @int = 10;
            Console.WriteLine(nameof(@int));
            FieldInfo fieldInfo = typeof(MyClass).GetField("int");
            Console.WriteLine(fieldInfo.GetValue(new MyClass()));
        }
        public class MyClass
        {
            public int @int = 20;
        }
    }
}