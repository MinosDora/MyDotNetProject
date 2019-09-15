using System;
using System.Reflection;
using MinoTool;
using ObjectLayoutInspector;

namespace DotNetTestProject
{
    /// <summary>
    /// 数组
    /// </summary>
    public class ArrayTests
    {
        /// <summary>
        /// 使用WinDbg测试元素为值类型的数组实例占用内存的大小
        /// </summary>
        public void Test1()
        {
            //占用字节数：24+4*3=36
            int[] ints = new int[3];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            Console.WriteLine(string.Join(",", ints));
            TypeLayout.PrintLayout<Array>();
            //Size: 8 bytes.Paddings: 0 bytes(% 0 of empty space)
            //|============================|
            //|   Object Header(8 bytes)   |
            //|----------------------------|
            //|  Method Table Ptr(8 bytes) |
            //|============================|
            //|============================|
        }

        /// <summary>
        /// 使用WinDbg测试元素为引用类型的数组实例占用内存的大小
        /// </summary>
        public void Test2()
        {
            //占用字节数：24+8*3=48
            string[] strings = new string[3];
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = string.Empty;
            }
            Console.WriteLine(string.Join(",", strings));
        }

        /// <summary>
        /// 使用Array.CreateInstance创建数组实例
        /// </summary>
        public void Test3()
        {
            int[] ints = Array.CreateInstance(typeof(int), 3) as int[];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            Console.WriteLine(string.Join(",", ints));
        }

        /// <summary>
        /// 测试二维数组访问速度，逐行访问较逐列访问速度更快（这是由于缓存Cache命中率的影响）
        /// 在Intel i7-8700中，逐列访问较逐行访问用时长约2倍
        /// </summary>
        public void Test4()
        {
            const int length = 5000;
            int[,] ints = new int[length, length];
            //先对数组中每个元素初始化，避免初始化带来的影响
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    ints[i, j] = 10;
                }
            }
            //逐行访问，约40毫秒
            using (StopwatchUtil.CreateStopwatch())
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        ints[i, j] = 10;  //较快
                    }
                }
            }
            //逐列访问，约120毫秒
            using (StopwatchUtil.CreateStopwatch())
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        ints[j, i] = 10;  //较慢
                    }
                }
            }
        }

        /// <summary>
        /// 测试TrySZReverse的条件，基元类型的SZ数组可以，自定义类型不可以
        /// </summary>
        public void Test5()
        {
            MethodInfo methodInfo = typeof(Array).GetMethod("TrySZReverse", BindingFlags.NonPublic | BindingFlags.Static);
            int[] ints = new int[] { 1, 2, 3, 4, 5 };
            bool result = (bool)methodInfo.Invoke(null, new object[] { ints, 0, 5 });
            Console.WriteLine(result);  //True
            Console.WriteLine(string.Join(",", ints));  //5,4,3,2,1

            MyStruct1[] myStruct1s = new MyStruct1[] { new MyStruct1 { Key = 1 }, new MyStruct1 { Key = 2 }, new MyStruct1 { Key = 3 } };
            result = (bool)methodInfo.Invoke(null, new object[] { myStruct1s, 0, 3 });
            Console.WriteLine(result);  //False
            Console.WriteLine(string.Join(",", myStruct1s));  //1,2,3
            Array.Reverse(myStruct1s);  //无法使用CLR默认实现，效率较差
        }
        private struct MyStruct1
        {
            public long Key;
            public override string ToString()
            {
                return Key.ToString();
            }
        }

        /// <summary>
        /// 测试数组是否为SZ数组（single-dimensional w/ zero as the lower bound，Single-dimensional, Zero-based，即一维且以0为下限，一维零基），w/ = with
        /// </summary>
        public void Test6()
        {
            Console.WriteLine(IsSingleDimensionalZeroBasedArray(typeof(int[])));  //True
            Console.WriteLine(IsSingleDimensionalZeroBasedArray(typeof(MyStruct1[])));  //True
            Console.WriteLine(IsSingleDimensionalZeroBasedArray(typeof(int[][])));  //True，交错数组本质上是数组的数组，因此也是一维数组
            Console.WriteLine(IsSingleDimensionalZeroBasedArray(typeof(int[,])));  //False，二维数组
        }
        private static bool IsSingleDimensionalZeroBasedArray(Type type)
        {
            //type.GetArrayRank()可以获取数组的维度，但不能判断是否为零基
            return type != null && type.IsArray && type == type.GetElementType().MakeArrayType();
        }
    }
}