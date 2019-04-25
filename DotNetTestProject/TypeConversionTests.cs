using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestProject
{
    /// <summary>
    /// 类型转换
    /// </summary>
    public class TypeConversionTests
    {
        /// <summary>
        /// 测试引用类型的隐式转换和显式转换
        /// </summary>
        public void Test1()
        {
            MyClass myClass = new MyClass();
            MyBaseClass myBaseClass = myClass;
            IMyInterface myInterface = new MyClass();
            myClass = (MyClass)myBaseClass;
            myClass = (MyClass)myInterface;
            Console.WriteLine(myClass.GetType().Name);
            Console.WriteLine(myBaseClass.GetType().Name);
        }
        public interface IMyInterface { }
        public class MyBaseClass { }
        public class MyClass : MyBaseClass, IMyInterface { }

        /// <summary>
        /// 测试内置值类型的Parse()方法
        /// </summary>
        public void Test2()
        {
            int num = int.Parse("25");
            Console.WriteLine(num);
            try
            {
                num = int.Parse(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                num = int.Parse("2.5");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                num = int.Parse("hello");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 测试内置值类型的TryParse()方法
        /// </summary>
        public void Test3()
        {
            bool isCanConvert = int.TryParse("hello", out int num);
            Console.WriteLine($"{nameof(num)} = {num}, {nameof(isCanConvert)} = {isCanConvert}.");
            isCanConvert = int.TryParse("25", out num);
            Console.WriteLine($"{nameof(num)} = {num}, {nameof(isCanConvert)} = {isCanConvert}.");
            isCanConvert = int.TryParse("2.5", out num);
            Console.WriteLine($"{nameof(num)} = {num}, {nameof(isCanConvert)} = {isCanConvert}.");
        }

        /// <summary>
        /// 测试基本类型转换帮助类System.Convert
        /// </summary>
        public void Test4()
        {
            int num = Convert.ToInt32("25");
            Console.WriteLine(num);
            num = Convert.ToInt32(null);
            Console.WriteLine(num);
            num = Convert.ToInt32(5.5f);
            Console.WriteLine(num);
            try
            {
                num = Convert.ToInt32("2500000000000000000000");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                num = Convert.ToInt32("2.5");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                num = Convert.ToInt32("hello");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            float num1 = Convert.ToSingle("2.5");
            Console.WriteLine(num1);
        }
    }
}