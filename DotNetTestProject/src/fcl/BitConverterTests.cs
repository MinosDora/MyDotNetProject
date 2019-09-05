using System;

namespace DotNetTestProject
{
    /// <summary>
    /// BitConverter
    /// </summary>
    public class BitConverterTests
    {
        /// <summary>
        /// 使用非安全代码获取本机是大端字节序还是小端字节序
        /// </summary>
        public unsafe void CodeSnippet1()
        {
            Console.WriteLine($"{nameof(BitConverter.IsLittleEndian)}: {BitConverter.IsLittleEndian}");
            int num = 10;
            byte* firstBytePtr = (byte*)(&num);
            Console.WriteLine(*firstBytePtr);
            Console.WriteLine(*(firstBytePtr + 1));
            Console.WriteLine(*(firstBytePtr + 2));
            Console.WriteLine(*(firstBytePtr + 3));
            if (*firstBytePtr == num)   //小端字节序
            {
                Console.WriteLine("Littile Endian");
            }
            else   //大端字节序
            {
                Console.WriteLine("Big Endian");
            }
        }
    }
}