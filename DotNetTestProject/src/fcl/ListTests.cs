using System;
using System.Collections.Generic;

namespace DotNetTestProject
{
    public class ListTests
    {
        /// <summary>
        /// 测试列表初始和添加一个元素后的Count和Capacity
        /// </summary>
        public void Test1()
        {
            List<int> list = new List<int>();
            Console.WriteLine(list.Count);  //0
            Console.WriteLine(list.Capacity);  //0
            list.Add(0);
            Console.WriteLine(list.Count);  //1
            Console.WriteLine(list.Capacity);  //4
        }

        /// <summary>
        /// 测试二分查找，前置条件为列表有序，否则返回值不正确
        /// </summary>
        public void Test2()
        {
            List<int> list = new List<int>() { 1, 1, 1, 1, 1 };
            Console.WriteLine(list.BinarySearch(1));  //2，二分查找得到第一个相等值的索引
            list = new List<int>() { 1, 2, 3, 5, 6 };
            int value = 4;
            int index = list.BinarySearch(value);  //二分查找未找到时的返回值为负值，其反码（~value）为插入该值时保证列表排序的索引
            Console.WriteLine(index);  //-4
            if (index >= 0)  //大于等于0正常插入
            {
                list.Insert(index, value);
            }
            else  //小于0取反后插入
            {
                list.Insert(~index, value);
            }
            Console.WriteLine(string.Join(",", list));  //1,2,3,4,5,6
        }
    }
}