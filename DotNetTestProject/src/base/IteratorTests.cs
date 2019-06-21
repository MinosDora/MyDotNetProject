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
        /// 对斐波那契数列使用迭代器
        /// </summary>
        public void CodeSnippet1()
        {
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