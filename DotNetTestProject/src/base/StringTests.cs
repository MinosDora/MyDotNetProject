using ObjectLayoutInspector;
using System;
using System.Collections.Generic;

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
            string str3 = "Hell" + "o";  //由编译器直接合并为"Hello"

            Console.WriteLine(ReferenceEquals(str, str1));   //False
            Console.WriteLine(ReferenceEquals(str, str3));   //True
            Console.WriteLine(str.GetHashCode());   //-327378614
            Console.WriteLine(str1.GetHashCode());  //-327378614
            Console.WriteLine(str3.GetHashCode());  //-327378614
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
        /// 但string实例大小占用规则为26+字符数*2
        /// </summary>
        public void Test6()
        {
            //                          //字节大小  内存地址  偏差
            string str = "a";           //28bytes  26620
            string str1 = "ab";         //30bytes  26660    40
            string str2 = "abc";        //32bytes  26720    40
            string str3 = "abcd";       //34bytes  26760    40
            string str4 = "abcde";      //36bytes  27030    270
            string str5 = "abcdef";     //38bytes  27100    70
            string str6 = "abcdefg";    //40bytes  27150    50
            string str7 = "abcdefgh";   //42bytes  27220    70
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

        /// <summary>
        /// 根据空格翻转字符串
        /// </summary>
        public void Test7()
        {
            string myStr = "I am a Boy";
            string[] strings = myStr.Split(' ');
            Array.Reverse(strings);
            Console.WriteLine(string.Join(" ", strings));

            char[] chars = myStr.ToCharArray();
            int startIndex = 0;
            char[] result = new char[chars.Length];
            for (int i = 0, length = chars.Length; i < length; i++)
            {
                if (chars[i] == ' ')
                {
                    int endIndex = i;
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        result[chars.Length - endIndex + j - startIndex] = chars[j];
                    }
                    result[chars.Length - endIndex - 1] = ' ';
                    startIndex = endIndex + 1;
                }
                if (i == chars.Length - 1)
                {
                    for (int j = startIndex; j < chars.Length; j++)
                    {
                        result[j - startIndex] = chars[j];
                    }
                }
            }
            Console.WriteLine(new string(result));
        }

        /// <summary>
        /// 测试通过不安全代码修改字符串，其哈希值会变化
        /// </summary>
        public unsafe void Test8()
        {
            string str = "Hello";
            Console.WriteLine(str.GetHashCode());
            fixed (char* p = str)
            {
                p[0] = 'C';
            }
            Console.WriteLine(str);
            Console.WriteLine(str.GetHashCode());
        }

        /// <summary>
        /// 将字符串中的字母转换大小写，打印所有可能的情况
        /// </summary>
        public void Test9()
        {
            ArrangeString("2a5b3c");
            //解题思路为二进制数值从0递增到2^n正好符合排列的规律，以n=3举例，000 001 010 011 100 101 110 111
            void ArrangeString(string str)
            {
                char[] chars = str.ToCharArray();
                //获取所有小写字母的集合
                List<int> indexs = new List<int>(chars.Length);
                for (int i = 0; i < chars.Length; i++)
                {
                    if (isLowerCharacter(chars[i]) || isUpperCharacter(chars[i]))
                    {
                        indexs.Add(i);
                    }
                }

                int indexCount = indexs.Count;
                //一共1<<indexCount种可能
                for (int i = 0; i < (1 << indexCount); i++)
                {
                    for (int j = 0; j < indexCount; j++)
                    {
                        bool toUpper = (i & (1 << j)) > 0;
                        int index = indexs[indexCount - j - 1];
                        char @char = chars[index];
                        if ((toUpper && isLowerCharacter(@char))
                            || (!toUpper && isUpperCharacter(@char)))
                        {
                            //使用异或运算进行快速大小写字母切换
                            chars[index] = (char)(@char ^ 0x20);
                        }
                    }
                    Console.WriteLine(new string(chars));
                }
            }
            //char类型的定义中包含IsLower和IsUpper的方法声明，可以直接使用
            bool isLowerCharacter(char @char)
            {
                return @char >= 'a' && @char <= 'z';
            }
            bool isUpperCharacter(char @char)
            {
                return @char >= 'A' && @char <= 'Z';
            }
        }
    }
}