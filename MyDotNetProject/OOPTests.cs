using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetProject
{
    /// <summary>
    /// 面向对象
    /// </summary>
    public class OOPTests
    {
        /// <summary>
        /// 测试多态性
        /// </summary>
        /// <param name="args"></param>
        public void Test1()
        {
            MyClass myClass = new MyClass();
            MyBaseClass myBaseClass = myClass;
            myBaseClass.MyFunc1();
            myBaseClass.MyFunc2();
            myClass.MyFunc1();
            myClass.MyFunc2();
        }
        class MyBaseClass
        {
            int num = 10;
            public virtual void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s {nameof(MyFunc1)} is called.");
            }
            public void MyFunc2()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s num is {num}.");
            }
        }
        class MyClass : MyBaseClass
        {
            int num = 20;
            public override void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyClass)}'s {nameof(MyFunc1)} is called.");
            }
            public new void MyFunc2()
            {
                Console.WriteLine($"{nameof(MyClass)}'s num is {num}.");
            }
        }
    }
}