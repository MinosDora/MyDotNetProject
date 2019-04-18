using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using MinoHelper;

namespace DotNetTestProject
{
    /// <summary>
    /// 委托
    /// </summary>
    public class DelegateTests
    {
        /// <summary>
        /// 测试直接调用方法、通过反射调用方法和使用委托调用方法的效率
        /// </summary>
        public void Test1()
        {
            int times = 10000000;
            MyClass myObj = new MyClass();
            using (StopwatchHelper.CreateStopwatch())
            {
                for (int i = 0; i < times; i++)
                {
                    myObj.MyFunc();
                }
            }
            using (StopwatchHelper.CreateStopwatch())
            {
                Type myType = typeof(MyClass);
                MethodInfo methodInfo = myType.GetMethod("MyFunc");
                for (int i = 0; i < times; i++)
                {
                    methodInfo.Invoke(myObj, null);
                }
            }

            using (StopwatchHelper.CreateStopwatch())
            {
                Type myType = typeof(MyClass);
                MethodInfo methodInfo = myType.GetMethod("MyFunc");
                Action action = (Action)methodInfo.CreateDelegate(typeof(Action), myObj);
                for (int i = 0; i < times; i++)
                {
                    action();
                }
            }
        }

        /// <summary>
        /// 测试委托增删后会创建新的委托实例
        /// </summary>
        public void Test2()
        {
            MyClass myClass = new MyClass();
            Action action = myClass.MyFunc;
            Console.WriteLine(action.GetHashCode());
            action += myClass.MyFunc;
            Console.WriteLine(action.GetHashCode());
        }

        public class MyClass
        {
            //[MethodImpl(MethodImplOptions.NoInlining)]
            public void MyFunc()
            {

            }
        }
    }
}