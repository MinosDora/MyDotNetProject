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
        public unsafe void Test1()
        {
            Console.WriteLine(sizeof(int));                 //4
            Console.WriteLine(Marshal.SizeOf<int>());       //4
            Console.WriteLine(sizeof(int*));                //8
            Console.WriteLine(Marshal.SizeOf(typeof(int*)));//8
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

            int num1 = 5, num2 = 6;
            num = num1++ * --num2;
            Console.WriteLine(num);
        }

        /// <summary>
        /// 测试标识符使用@符号时标识符的名称
        /// </summary>
        public void Test4()
        {
            int @int = 10;
            Console.WriteLine(nameof(@int));
            FieldInfo fieldInfo = typeof(MyClass).GetField("int");
            Console.WriteLine($"{fieldInfo.Name}'s value is {fieldInfo.GetValue(new MyClass())}.");
        }
        public class MyClass
        {
            public int @int = 20;
        }

        /// <summary>
        /// 条件运算符和null合并运算符联合使用
        /// </summary>
        public void CodeSnippet1()
        {
            MyClass1 myClass1 = new MyClass1 { IsIt = true };
            Console.WriteLine(myClass1?.MyStr ?? "haha");
            if (myClass1?.IsIt ?? false)
            {
                Console.WriteLine("It is.");
            }
        }
        private class MyClass1
        {
            public string MyStr;
            public bool IsIt;
        }
    }
}