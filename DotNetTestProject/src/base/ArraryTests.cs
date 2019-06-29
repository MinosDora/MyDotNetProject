using ObjectLayoutInspector;
using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 数组
    /// </summary>
    public class ArraryTests
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
            TypeLayout.PrintLayout<Array>();
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
    }
}