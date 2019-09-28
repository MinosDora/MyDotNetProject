using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 基元类型
    /// </summary>
    public class PrimitiveTypeTests
    {
        /// <summary>
        /// 测试char与int之间的相互转换
        /// </summary>
        public void Test1()
        {
            char charA = 'A', charB = (char)65;
            Console.WriteLine(charA == charB);      //True
            Console.WriteLine(charA + 1);           //66，char和int相加，char会隐式转换为int，然后执行相加操作，返回int
            Console.WriteLine((char)(charA + 1));   //B，接上，返回的int值强制转换为char类型输出
        }

        /// <summary>
        /// 测试两个字符的UTF-16字符
        /// </summary>
        public void Test2()
        {
            Console.WriteLine(sizeof(char));    //2
            //char charA = '𠬠';   //需要两个UTF-16字符，无法赋值给char
            string str = "𠬠";
            Console.WriteLine(str.Length);      //2
        }
    }
}