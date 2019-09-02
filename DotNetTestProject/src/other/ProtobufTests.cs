using System;
using System.IO;
using ProtoBuf;

namespace DotNetTestProject
{
    public class ProtobufTests
    {
        /// <summary>
        /// protobuf的序列化/反序列化
        /// </summary>
        public void CodeSnippet1()
        {
            using (FileStream fileStream = new FileStream("../proto.txt", FileMode.OpenOrCreate))
            {
                Serializer.Serialize(fileStream, new MyClass { MyStr = "Hello World.", MyNum = 20 });
                Console.WriteLine("Serialize Success");
            }

            using (FileStream fileStream = new FileStream("../proto.txt", FileMode.OpenOrCreate))
            {
                MyClass myClass = Serializer.Deserialize<MyClass>(fileStream);
                Console.WriteLine(myClass.MyStr);
                Console.WriteLine(myClass.MyNum);
                Console.WriteLine("Deserialize Success");
            }
        }
        [ProtoContract]
        private class MyClass
        {
            [ProtoMember(1)]
            public string MyStr;
            [ProtoMember(2)]
            public int MyNum;
        }
    }
}