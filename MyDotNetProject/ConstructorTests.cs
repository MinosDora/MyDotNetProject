using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetProject
{
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
            public static string MyStaticStr = MyStaticStr1;    //null
            public static string MyStaticStr1 = "10";
            private string myStr = MyStaticStr1;                //"10"

            public void MyFunc()
            {
                Console.WriteLine($"{nameof(MyStaticStr)}: {(MyStaticStr == null ? "null" : MyStaticStr)}");
                Console.WriteLine($"{nameof(myStr)}: {myStr}");
            }
        }
    }
}