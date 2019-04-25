using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new MyClass().ShallowCopy();
        }
        class MyBaseClass
        {
            public void ShallowCopy()
            {
                Console.WriteLine(this.MemberwiseClone().GetType());
            }
        }
        class MyClass : MyBaseClass
        {

        }
    }
}