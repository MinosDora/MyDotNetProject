using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetTestProject
{
    /// <summary>
    /// Josn.net
    /// </summary>
    public class JsonDotNetTests
    {
        public void Test1()
        {
            MyClass myClass = new MyClass();
            string jsonStr = JsonConvert.SerializeObject(myClass);
            Console.WriteLine(jsonStr);
            JObject jObject = JObject.Parse(jsonStr);
            Console.WriteLine(jObject.ToString(Formatting.None));
        }

        private class MyClass
        {
            public int MyNum = 10;
            public string MyStr = "Hello World";
        }
    }
}