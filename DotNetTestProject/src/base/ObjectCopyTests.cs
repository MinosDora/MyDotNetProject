using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 对象拷贝
    /// </summary>
    public class ObjectCopyTests
    {
        /// <summary>
        /// 测试浅拷贝对象的类型
        /// </summary>
        public void Test1()
        {
            new MyClass().ShallowCopy();  //DotNetTestProject.ObjectCopyTests+MyClass
        }
        class MyBaseClass
        {
            public void ShallowCopy()
            {
                Console.WriteLine(this.MemberwiseClone().GetType());
            }
        }
        class MyClass : MyBaseClass { }
    }
}