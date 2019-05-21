using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DotNetTestProject
{
    /// <summary>
    /// 泛型
    /// </summary>
    public class GenericTests
    {
        /// <summary>
        /// 测试非托管类型约束
        /// </summary>
        public void Test1()
        {
            MyClass<int> myClass = new MyClass<int>();
            //MyClass<MyStruct> myClass1 = new MyClass<MyStruct>();  //error
            //MyClass<MyStruct2<int>> myClass2 = new MyClass<MyStruct2<int>>;  //error
        }
        public class MyClass<T> where T : unmanaged
        {
            public int num;
        }
        public struct MyStruct
        {
            public MyStruct1 myStruct;
        }
        public struct MyStruct1
        {
            public MyStruct2<int> str;
        }
        public struct MyStruct2<T> where T : unmanaged { }

        /// <summary>
        /// 使用泛型实现回调
        /// </summary>
        public void CodeSnippet1()
        {
            myFunc<MyClass1>(callback);
        }
        private void myFunc<T>(Action<T> action) where T : class, IMyInterface
        {
            Console.WriteLine(typeof(T));
            T result = JsonConvert.DeserializeObject<T>("{\"MyNum\":20}");
            action(result);
        }
        private void callback(MyClass1 myClass)
        {
            Console.WriteLine(myClass.MyNum);
        }
        public interface IMyInterface { }
        public class MyClass1 : IMyInterface
        {
            public int MyNum;
        }
    }
}