using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDotNetProject
{
    /// <summary>
    /// 不安全代码
    /// </summary>
    public unsafe class UnsafeCodeTests
    {
        /// <summary>
        /// 使用不安全代码实现斐波那契数列
        /// </summary>
        public void CodeSnippet1()
        {
            int intsLength = 10;
            int* intsPtr = stackalloc int[intsLength];
            int* p = intsPtr;
            *p++ = *p++ = 1;
            for (int i = 2; i < intsLength; ++i, ++p)
            {
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < intsLength; i++)
            {
                Console.WriteLine(intsPtr[i]);
            }
        }
    }
}