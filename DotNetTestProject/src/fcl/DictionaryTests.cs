using System;
using System.Collections.Generic;

namespace DotNetTestProject
{
    /// <summary>
    /// Dictionary
    /// </summary>
    public class DictionaryTests
    {
        /// <summary>
        /// 测试字典在删除中间一个元素时再添加后，其元素的顺序
        /// </summary>
        public void Test1()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
            };
            dic.Remove(2);
            dic.Add(4, 4);
            foreach (var item in dic)
            {
                Console.WriteLine(item);  //[1, 1]
                                          //[4, 4]
                                          //[3, 3]
            }
        }
    }
}