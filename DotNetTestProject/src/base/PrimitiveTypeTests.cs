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
            Console.WriteLine(charA == charB);
            Console.WriteLine(charA + 1);
            Console.WriteLine((char)(charA + 1));
        }
    }
}