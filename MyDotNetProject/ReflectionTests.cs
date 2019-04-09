using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetProject
{
    public class ReflectionTests
    {
        public void CodeSnippet1()
        {
            byte[] ils = typeof(MyClass).GetMethod("MyFunc").GetMethodBody().GetILAsByteArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < ils.Length; i++)
            {
                stringBuilder.Append(ils[i].ToString("X2"));
                stringBuilder.Append(" ");
            }
            Console.WriteLine(stringBuilder);
        }

        public class MyClass
        {
            public void MyFunc()
            {

            }
        }
    }
}