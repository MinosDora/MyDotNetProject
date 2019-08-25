using MinoTool;
using ObjectLayoutInspector;
using System;

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
            //逐行访问
            using (StopwatchUtil.CreateStopwatch())
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        ints[i, j] = 10;  //快
                    }
                }
            }
            //逐列访问
            using (StopwatchUtil.CreateStopwatch())
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        ints[j, i] = 10;  //慢
                    }
                }
            }
        }
    }
}