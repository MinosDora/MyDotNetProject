using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 字符串
    /// </summary>
    public class StringTests
    {
        /// <summary>
        /// 测试CLR内部字符串存储规则
        /// </summary>
        public void Test1()
        {
            string str = "Hello";
            string str1 = "Hell";
            string str2 = "oo";
            str1 += str2.Substring(0, 1);
            string str3 = "Hell" + "o";

            Console.WriteLine(object.ReferenceEquals(str, str1));   //False
            Console.WriteLine(object.ReferenceEquals(str, str3));   //True
        }

        /// <summary>
        /// 测试字符串的不可变性
        /// </summary>
        public void Test2()
        {
            string str1 = "Hello";
            string str2 = str1;
            string str3 = str1.Substring(0, 2);
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
        }

        /// <summary>
        /// 测试逐字字符串
        /// </summary>
        public void Test3()
        {
            Console.WriteLine(@"Hello ""World""");
        }
    }
}