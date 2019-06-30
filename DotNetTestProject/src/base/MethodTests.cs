using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 方法
    /// </summary>
    public class MethodTests
    {
        /// <summary>
        /// 局部函数Local Function
        /// </summary>
        public void CodeSnippet1()
        {
            string Foo()
            {
                return "Hello";
            }
            Console.WriteLine(Foo());
            Func<string> func = Foo;
            Console.WriteLine(func?.Invoke());
        }
    }
}