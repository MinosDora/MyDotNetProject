using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestProject
{
    /// <summary>
    /// 引用局部变量和引用返回值
    /// </summary>
    public class RefLocalsAndRefReturnsTests
    {
        /// <summary>
        /// 引用局部变量
        /// </summary>
        public void CodeSnippet1()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            ref int a = ref nums[0];
            a = a + 9;
            Console.WriteLine(string.Join(",", nums));
        }
    }
}