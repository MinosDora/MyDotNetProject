using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTestProject
{
    /// <summary>
    /// 迭代器
    /// </summary>
    public class IteratorTests
    {
        /// <summary>
        /// 使用迭代器实现斐波那契数列
        /// </summary>
        public void CodeSnippet1()
        {
            //正常方式打印斐波那契数列
            int index = 0;
            foreach (var item in FibonacciIterator())
            {
                if (index >= 100)
                {
                    break;
                }
                Console.WriteLine(item);
                index += 1;
            }
            //使用Linq打印斐波那契数列
            foreach (var i in FibonacciIterator().Take(100))
            {
                Console.WriteLine(i);
            }
        }
        private IEnumerable<long> FibonacciIterator()
        {
            long current = 1, next = 1;

            while (true)
            {
                yield return current;
                next = current + (current = next);
            }
        }
    }
}