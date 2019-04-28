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
        public enum MyEnum
        {
            MyEnum1 = 0x1,
            MyEnum2 = 0x2,
        }
    }
}