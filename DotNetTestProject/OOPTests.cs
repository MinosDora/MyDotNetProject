using System;

namespace DotNetTestProject
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
            Console.WriteLine($"{nameof(myClass)}'s num is {myClass.num}.");
            Console.WriteLine($"{nameof(myBaseClass)}'s num is {myBaseClass.num}.");
        }
        class MyBaseClass
        {
            public int num = 10;
            public virtual void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s {nameof(MyFunc1)} is called, num is {num}.");
            }
            public void MyFunc2()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s {nameof(MyFunc1)} is called, num is {num}.");
            }
        }
        class MyClass : MyBaseClass
        {
            public new int num = 20;
            public override void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyClass)}'s {nameof(MyFunc1)} is called, num is {num}.");
            }
            public new void MyFunc2()
            {
                Console.WriteLine($"{nameof(MyClass)}'s {nameof(MyFunc1)} is called, num is {num}.");
            }
        }
    }
}