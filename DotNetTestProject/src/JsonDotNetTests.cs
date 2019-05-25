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

        /// <summary>
        /// 测试自定义转换过程
        /// </summary>
        public void CodeSnippet3()
        {
            string jsonStr = @"{""MyBool"": ""TRUE""}";
            MyClass1 myClass1 = JsonConvert.DeserializeObject<MyClass1>(jsonStr);
            Console.WriteLine(myClass1.MyBool);
            Console.WriteLine(JsonConvert.SerializeObject(myClass1));
        }
        private class MyClass1
        {
            [JsonConverter(typeof(MyBoolConverter))]
            public bool MyBool;
        }
    }

    /// <summary>
    /// 布尔类型数据转换规则
    /// </summary>
    public class MyBoolConverter : JsonConverter
    {
        private const string TrueStr = "TRUE";
        private const string FalseStr = "FALSE";
        public override bool CanConvert(Type objectType) => true;

        //反序列化
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                if ((string)reader.Value == TrueStr)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //序列化
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(bool))
            {
                bool result = (bool)value;
                if (result)
                {
                    writer.WriteValue(TrueStr);
                }
                else
                {
                    writer.WriteValue(FalseStr);
                }
            }
        }
    }
}