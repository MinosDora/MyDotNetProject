using ObjectLayoutInspector;
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

        /// <summary>
        /// 测试字符串插值
        /// </summary>
        public void Test4()
        {
            int num = 10;
            Console.WriteLine($"num:{num}");
            Console.WriteLine($"{{num}}:{num}");
        }

        /// <summary>
        /// 测试同时使用逐字字符串和字符串插值
        /// </summary>
        public void Test5()
        {
            int num = 10;
            Console.WriteLine($@"""{{num}}"":{num}");
        }

        /// <summary>
        /// 使用WinDbg测试string实例占用内存的大小，经过测试，其内存地址并未严格按照该大小排布
        /// </summary>
        public void Test6()
        {
            //                          //字节大小  内存地址&偏差
            string str = "a";           //28bytes  26620
            string str1 = "ab";         //30bytes  26660 40
            string str2 = "abc";        //32bytes  26720 40
            string str3 = "abcd";       //34bytes  26760 40
            string str4 = "abcde";      //36bytes  27030 270
            string str5 = "abcdef";     //38bytes  27100 70
            string str6 = "abcdefg";    //40bytes  27150 50
            string str7 = "abcdefgh";   //42bytes  27220 70
            Console.WriteLine(str);
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
            Console.WriteLine(str4);
            Console.WriteLine(str5);
            Console.WriteLine(str6);
            Console.WriteLine(str7);
            TypeLayout.PrintLayout<string>();
        }
    }
}