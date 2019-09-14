using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 装箱和拆箱
    /// </summary>
    public class BoxAndUnBoxTests
    {
        /// <summary>
        /// 测试装箱后类型
        /// </summary>
        public void Test1()
        {
            int myNum = 1;
            object myObj = myNum;
            IEquatable<int> equatable = myNum;
            Console.WriteLine(myNum.GetType());  //System.Int32
            Console.WriteLine(myObj.GetType());  //System.Int32
            Console.WriteLine(equatable.GetType());  //System.Int32
            MyEnum myEnum = MyEnum.MyEnum_1;
            object myEnumObj = myEnum;
            Console.WriteLine(myEnum.GetType());  //DotNetTestProject.BoxAndUnBoxTests+MyEnum
            Console.WriteLine(myEnumObj.GetType());  //DotNetTestProject.BoxAndUnBoxTests+MyEnum
        }

        /// <summary>
        /// 测试枚举类型和其基本类型直接的拆箱和装箱
        /// </summary>
        public void Test2()
        {
            MyEnum myEnum = MyEnum.MyEnum_1;
            object myEnumObj = myEnum;
            int myNum = (int)myEnumObj;
            Console.WriteLine(myNum);
            myEnumObj = myNum;
            myEnum = (MyEnum)myEnumObj;
            Console.WriteLine(myEnum);
        }
        public enum MyEnum
        {
            MyEnum_1,
        }
    }
}