using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 不安全代码
    /// </summary>
    public unsafe class UnsafeCodeTests
    {
        /// <summary>
        /// 测试堆内存中的对象一般情况下是连续分配的
        /// </summary>
        public void Test1()
        {
            MyClass myClass1 = new MyClass();
            MyClass myClass2 = new MyClass();
            fixed (int* p1 = &myClass1.MyNum)
            {
                Console.WriteLine((int)p1);  //1360735672
            }
            fixed (int* p2 = &myClass2.MyNum)
            {
                Console.WriteLine((int)p2);  //1360735696
            }
        }
        private class MyClass
        {
            public int MyNum;
        }

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