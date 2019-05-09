using System;
using Newtonsoft.Json;

namespace DotNetTestProject
{
    /// <summary>
    /// 协变和逆变
    /// </summary>
    public class CovarianceAndContravarianceTests
    {
        public void Test1()
        {
            Action<MyClass> action = (myclass) =>
            {
                Console.WriteLine("Test");
            };
            myFunc(action);
        }
        private void myFunc<T>(Action<T> action) where T : class, IMyInterface
        {
            action(JsonConvert.DeserializeObject("", typeof(T)) as T);
        }

        public interface IMyInterface { }
        public class MyClass : IMyInterface { }
    }
}