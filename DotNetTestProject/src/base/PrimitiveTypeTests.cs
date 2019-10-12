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

        /// <summary>
        /// 测试溢出检查
        /// </summary>
        public void Test3()
        {
            byte a = 100;
            byte b = (byte)(a + 200);
            Console.WriteLine(b);
            try
            {
                checked
                {
                    b = (byte)(a + 200);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}