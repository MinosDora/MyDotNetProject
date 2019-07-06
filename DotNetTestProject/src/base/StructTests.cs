using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 结构
    /// </summary>
    public class StructTests
    {

        /// <summary>
        /// 结构定义的最佳实践
        /// </summary>
        private struct MyStruct : IEquatable<MyStruct>  //实现IEquatable<T>接口用于泛型/泛型集合
        {
            public int MyNum;

            public override bool Equals(object obj)  //会对实参进行装箱
            {
                if (!(obj is MyStruct))
                {
                    return false;
                }
                MyStruct other = (MyStruct)obj;  //拆箱
                return this.Equals(other);
            }
            public override int GetHashCode()  //避免使用散列集合类时装箱并提供高效实现
            {
                return MyNum.GetHashCode();
            }
            public override string ToString()  //避免装箱
            {
                return MyNum.ToString();
            }

            public bool Equals(MyStruct other)  //避免比较时实参装箱，避免使用泛型时装箱
            {
                return this.MyNum == other.MyNum;
            }
            public static bool operator ==(MyStruct left, MyStruct right)  //比较时通常采用==运算符
            {
                return left.Equals(right);
            }
            public static bool operator !=(MyStruct left, MyStruct right)
            {
                return !(left == right);
            }
        }
    }
}