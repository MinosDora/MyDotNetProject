using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 枚举
    /// </summary>
    public class EnumTests
    {
        /// <summary>
        /// 测试枚举类型编译阶段的操作
        /// </summary>
        public void Test1()
        {
            MyEnum myEnum = MyEnum.MyEnum1;
            MyEnum myEnum2 = myEnum | MyEnum.MyEnum2;
            MyFunc(myEnum2);
        }
        public static void MyFunc(MyEnum my)
        {
            Console.WriteLine(my);
        }

        /// <summary>
        /// 测试枚举没有枚举数=0的情况时的默认值
        /// </summary>
        public void Test2()
        {
            Console.WriteLine(default(MyEnum));
        }

        /// <summary>
        /// 测试枚举组合及其位运算
        /// </summary>
        public void Test3()
        {
            MyEnum myEnum = (MyEnum)7;
            Console.WriteLine(myEnum);
            Console.WriteLine((myEnum & MyEnum.MyEnum2) > 0);
            Console.WriteLine(myEnum.HasFlag(MyEnum.MyEnum2));
            myEnum = (MyEnum)9;
            Console.WriteLine(myEnum);
            Console.WriteLine((myEnum & MyEnum.MyEnum1) > 0);
            Console.WriteLine(myEnum.HasFlag(MyEnum.MyEnum1));
        }

        [System.Flags]
        public enum MyEnum
        {
            MyEnum1 = 0x1,
            MyEnum2 = 0x2,
            MyEnum3 = 0x4,
        }
    }
}