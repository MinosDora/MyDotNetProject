using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 方法
    /// </summary>
    public class MethodTests
    {
        /// <summary>
        /// 测试IL指令call和callvir
        /// </summary>
        public void Test1()
        {
            MyBaseClass myBaseClass = new MyClass();
            //方法调用                       //IL指令
            MyBaseClass.MyStaticFunc();     //call
            myBaseClass.MyFunc1();          //callvirt
            new MyBaseClass().MyFunc1();    //callvirt
            myBaseClass.MyFunc2();          //callvirt
            new MyBaseClass().MyFunc2();    //call

            //下面的方调用在IL代码中是通过callvirt指令调用的，如果使用dnSpy将后者改为call，则结果会不同，借此可理解两个指令的区别
            myBaseClass.MyFunc1();  //不修改IL指令，结果为MyClass's MyFunc1 is called.
            myBaseClass.MyFunc1();  //修改为call指令，结果为MyBaseClass's MyFunc1 is called.
        }
        class MyBaseClass
        {
            public virtual void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s {nameof(MyFunc1)} is called.");
            }
            public void MyFunc2()
            {
                Console.WriteLine($"{nameof(MyBaseClass)}'s {nameof(MyFunc2)} is called.");
            }
            public static void MyStaticFunc() { }
        }
        class MyClass : MyBaseClass
        {
            public override void MyFunc1()
            {
                Console.WriteLine($"{nameof(MyClass)}'s {nameof(MyFunc1)} is called.");
            }
        }

        private int retVal = 10;
        /// <summary>
        /// 测试方法返回值可以使用variable = value;的格式，先将variable赋值，然后将其返回
        /// </summary>
        public void Test2()
        {
            Console.WriteLine(MyFunc());

            //int MyFunc() => retVal = 20;  //除普通方法外，对属性、索引器及对应的方法体表达式都适用
            int MyFunc()
            {
                //do...
                return retVal = 20;
            }
            Console.WriteLine(retVal);
        }

        /// <summary>
        /// 局部函数Local Function，类似闭包的实现形式，使用嵌套类实现
        /// </summary>
        public void CodeSnippet1()
        {
            string Foo()  //会在当前类型的定义中添加一个嵌套类<>c，将此方法声明在该嵌套类中
            {
                return "Hello";
            }
            Console.WriteLine(Foo());
            Func<string> func = Foo;
            Console.WriteLine(func?.Invoke());
        }
    }
}