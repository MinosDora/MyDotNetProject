using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetProject
{
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
    }
}