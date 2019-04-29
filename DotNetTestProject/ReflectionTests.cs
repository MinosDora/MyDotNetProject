using System;
using System.Reflection;
using System.Text;

namespace DotNetTestProject
{
    /// <summary>
    /// 反射
    /// </summary>
    public class ReflectionTests
    {
        /// <summary>
        /// 测试通过反射调用泛型方法
        /// </summary>
        public void Test1()
        {
            MyClass myClass = new MyClass();
            Type type = typeof(MyClass);
            MethodInfo methodInfo = type.GetMethod("MyFunc");
            methodInfo = methodInfo.MakeGenericMethod(typeof(int));
            methodInfo.Invoke(myClass, null);
        }
        public class MyClass
        {
            public void MyFunc<T>()
            {
                Console.WriteLine(typeof(T));
            }
        }

        /// <summary>
        /// 获取方法体的IL字节数组
        /// </summary>
        public void CodeSnippet1()
        {
            byte[] ils = typeof(MyClass1).GetMethod("MyFunc").GetMethodBody().GetILAsByteArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < ils.Length; i++)
            {
                stringBuilder.Append(ils[i].ToString("X2"));
                stringBuilder.Append(" ");
            }
            Console.WriteLine(stringBuilder);
        }
        public class MyClass1
        {
            public void MyFunc()
            {

            }
        }
    }
}