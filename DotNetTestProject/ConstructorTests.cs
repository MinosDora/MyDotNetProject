using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public class ConstructorTests
    {
        /// <summary>
        /// 测试实例构造函数和实例字段、静态字段的执行顺序
        /// </summary>
        public void Test1()
        {
            new MyClass().MyFunc();
        }

        public class MyClass
        {
            public int myNum = MyStaticNum2;  //10
            public static int MyStaticNum1 = MyStaticNum2;  //0
            public static int MyStaticNum2 = 10;

            public void MyFunc()
            {
                Console.WriteLine($"{nameof(MyStaticNum1)}: {MyStaticNum1}");
                Console.WriteLine($"{nameof(MyStaticNum2)}: {MyStaticNum2}");
                Console.WriteLine($"{nameof(myNum)}: {myNum}");
            }
        }
    }
}