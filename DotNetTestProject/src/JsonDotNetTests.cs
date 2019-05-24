using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DotNetTestProject
{
    /// <summary>
    /// Json.net
    /// </summary>
    public class JsonDotNetTests
    {
        /// <summary>
        /// 标准序列化和反序列化
        /// </summary>
        public void CodeSnippet1()
        {
            MyClass myClass = new MyClass { MyNum = 10, MyStr = "Hello World" };
            string jsonStr = JsonConvert.SerializeObject(myClass);
            Console.WriteLine(jsonStr);
            Console.WriteLine(JsonConvert.SerializeObject(myClass, Formatting.Indented));
            Console.WriteLine(JsonConvert.DeserializeObject<MyClass>(jsonStr).MyNum);
        }

        /// <summary>
        /// Json.Linq To Object
        /// </summary>
        public void CodeSnippet2()
        {
            string jsonStr = @"{""MyNum"": 10,""MyStr"": ""Hello World""}";
            JObject jObject = JObject.Parse(jsonStr);
            Console.WriteLine(jObject.ToString());
            Console.WriteLine(jObject.ToString(Formatting.None));
            Console.WriteLine(jObject.ToString(Formatting.Indented));
            Console.WriteLine(jObject["MyStr"].Value<string>());
            jObject.Add("MyStr2", "HaHa");
            Console.WriteLine(jObject.ToString(Formatting.None));
        }
        private class MyClass
        {
            public int MyNum;
            public string MyStr;
        }
    }
}