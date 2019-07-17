using System;
using System.Reflection;
using MinoTool;

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
            MyClass1 myObj = new MyClass1();
            using (StopwatchUtil.CreateStopwatch())
            {
                for (int i = 0; i < times; i++)
                {
                    myObj.MyFunc();
                }
            }
            using (StopwatchUtil.CreateStopwatch())
            {
                Type myType = typeof(MyClass1);
                MethodInfo methodInfo = myType.GetMethod("MyFunc");
                for (int i = 0; i < times; i++)
                {
                    methodInfo.Invoke(myObj, null);
                }
            }

            using (StopwatchUtil.CreateStopwatch())
            {
                Type myType = typeof(MyClass1);
                MethodInfo methodInfo = myType.GetMethod("MyFunc");
                Action action = (Action)methodInfo.CreateDelegate(typeof(Action), myObj);
                for (int i = 0; i < times; i++)
                {
                    action();
                }
            }
        }
        private class MyClass1
        {
            //[MethodImpl(MethodImplOptions.NoInlining)]
            public void MyFunc()
            {

            }
        }

        /// <summary>
        /// 测试委托增删后会创建新的委托实例
        /// </summary>
        public void Test2()
        {
            MyClass2 myClass = new MyClass2();
            Action action = myClass.MyFunc;
            Console.WriteLine(action.GetHashCode());
            action += myClass.MyFunc;
            Console.WriteLine(action.GetHashCode());
        }
        private class MyClass2
        {
            public void MyFunc()
            {

            }
        }
    }
}