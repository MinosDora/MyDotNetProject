using System;
using System.Reflection;

namespace DotNetTestProject
{
    /// <summary>
    /// 属性
    /// </summary>
    public class PropertyTests
    {
        /// <summary>
        /// 自动属性在声明时赋值
        /// </summary>
        private string MyStr { get; set; } = "Hello";

        /// <summary>
        /// 只读属性表达式主体
        /// </summary>
        private int MyNum => 10;

        /// <summary>
        /// 使用反射获取类型的属性和字段信息，自动属性会创建字段，只读属性不会创建字段
        /// </summary>
        public void Test1()
        {
            Console.WriteLine("----------Propertys----------");
            PropertyInfo[] propertyInfos = typeof(PropertyTests).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                Console.WriteLine(propertyInfos[i].Name);
            }

            Console.WriteLine("----------Fields----------");
            FieldInfo[] fileInfos = typeof(PropertyTests).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            for (int i = 0; i < fileInfos.Length; i++)
            {
                Console.WriteLine(fileInfos[i].Name);
            }
        }
    }
}