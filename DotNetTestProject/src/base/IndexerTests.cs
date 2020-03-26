using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 索引器
    /// </summary>
    public class IndexerTests
    {
        /// <summary>
        /// 测试数组和索引器的实现方式差别
        /// </summary>
        public void Test1()
        {
            Vector2[] vector2s = new Vector2[10];
            for (int i = 0; i < vector2s.Length; i++)
            {
                //通过ldelema指令返回托管指针类型对象，可以对其直接进行修改
                vector2s[i].x = i;
                vector2s[i].y = i * 10;
            }

            for (int i = 0; i < vector2s.Length; i++)
            {
                Console.WriteLine(vector2s[i].ToString());
            }

            Vector2s vector2S = new Vector2s(10);
            for (int i = 0; i < 10; i++)
            {
                //通过调用索引器方法返回值类型对象，不可以直接对其进行修改，否则会报编译器错误CS1612
                //CS1612:https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/compiler-messages/cs1612
                //vector2S[i].x = i;
                //vector2S[i].y = i * 10;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(vector2S[i]);
            }
        }
        struct Vector2
        {
            public int x;
            public int y;

            public override string ToString()
            {
                return $"x:{x}, y:{y}";
            }
        }
        //实现索引器的类型，这里可以是值类型也可以是引用类型
        struct Vector2s
        {
            private Vector2[] vector2s;

            public Vector2s(int count)
            {
                vector2s = new Vector2[10];
                for (int i = 0; i < vector2s.Length; i++)
                {
                    vector2s[i].x = i;
                    vector2s[i].y = i * 10;
                }
            }

            public Vector2 this[int index]
            {
                get
                {
                    return vector2s[index];
                }
            }
        }
    }
}