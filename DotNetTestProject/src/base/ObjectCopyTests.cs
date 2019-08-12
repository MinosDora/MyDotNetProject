using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 对象拷贝
    /// </summary>
    public class ObjectCopyTests
    {
        /// <summary>
        /// 测试对象浅拷贝，拷贝出的对象类型是被拷贝对象的运行时类型
        /// </summary>
        public void Test1()
        {
            Console.WriteLine(new MyClass().ShallowCopy().GetType());  //DotNetTestProject.ObjectCopyTests+MyClass
        }
        class MyBaseClass
        {
            public MyBaseClass ShallowCopy()
            {
                return this.MemberwiseClone() as MyBaseClass;
            }
        }
        class MyClass : MyBaseClass { }
    }
}