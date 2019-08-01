using System;
using System.Collections.Generic;

namespace DotNetTestProject
{
    /// <summary>
    /// 集合
    /// </summary>
    public class CollectionTests
    {
        /// <summary>
        /// 使用堆栈匹配括号
        /// </summary>
        public void Test1()
        {
            Console.WriteLine(IsCorrect("{}[]()"));
        }
        private bool IsCorrect(string str)
        {
            Stack<char> chars = new Stack<char>(5);
            char[] strChars = str.ToCharArray();
            for (int i = 0; i < strChars.Length; i++)
            {
                if (strChars[i] == '(' || strChars[i] == '[' || strChars[i] == '{')
                {
                    chars.Push(strChars[i]);
                }
                else if (strChars[i] == ')' || strChars[i] == ']' || strChars[i] == '}')
                {
                    if (chars.Count == 0)
                    {
                        return false;
                    }
                    char reg = chars.Pop();
                    if ((reg == '(' && strChars[i] != ')')
                        || (reg == '[' && strChars[i] != ']')
                        || (reg == '{' && strChars[i] != '}')
                        )
                    {
                        return false;
                    }
                }
            }
            if (chars.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}