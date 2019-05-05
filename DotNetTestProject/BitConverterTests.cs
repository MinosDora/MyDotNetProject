using System;

namespace DotNetTestProject
{
    /// <summary>
    /// BitConverter
    /// </summary>
    public class BitConverterTests
    {
        /// <summary>
        /// 测试大端字节序和小端字节序
        /// </summary>
        public unsafe void Test1()
        {
            Console.WriteLine(BitConverter.IsLittleEndian);
            int num = 10;
            byte* firstBytePtr = (byte*)(&num);
            Console.WriteLine(*firstBytePtr);
            Console.WriteLine(*(firstBytePtr + 1));
            Console.WriteLine(*(firstBytePtr + 2));
            Console.WriteLine(*(firstBytePtr + 3));
            if (*firstBytePtr == num)
            {
                Console.WriteLine("Littile Endian");
            }
            else
            {
                Console.WriteLine("Big Endian");
            }
        }
    }
}