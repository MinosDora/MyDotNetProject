using System;

namespace DotNetTestProject
{
    /// <summary>
    /// Undocumented Keywords
    /// </summary>
    public class UndocumentedKeywordsTests
    {
        /// <summary>
        /// __makeref、__reftype和__refvalue关键字的使用
        /// </summary>
        public void Test1()
        {
            int num = 10;
            TypedReference typedReference = __makeref(num);
            Type type = __reftype(typedReference);
            Console.WriteLine(type);
            int num1 = __refvalue(typedReference, int);
            Console.WriteLine(num1);
        }

        /// <summary>
        /// __arglist关键字的使用
        /// </summary>
        /// <param name="__arglist"></param>
        public void Test2()
        {
            TestVarargs(__arglist(10, "100"));
        }

        private void TestVarargs(__arglist)
        {
            ArgIterator ai = new ArgIterator(__arglist);
            while (ai.GetRemainingCount() > 0)
            {
                TypedReference tr = ai.GetNextArg();
                Console.WriteLine(TypedReference.ToObject(tr));
            }
        }
    }
}
