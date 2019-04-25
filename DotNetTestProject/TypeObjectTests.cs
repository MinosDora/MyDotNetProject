using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 类型对象
    /// </summary>
    public class TypeObjectTests
    {
        /// <summary>
        /// 测试基类方法中通过this.GetType()获取实例的类型
        /// </summary>
        public void Test1()
        {
            new MyClass();
        }
        class MyBaseClass
        {
            public MyBaseClass()
            {
                Console.WriteLine(this.GetType());
            }
        }
        class MyClass : MyBaseClass
        {

        }
    }
}