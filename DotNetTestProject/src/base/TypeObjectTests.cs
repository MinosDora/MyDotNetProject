using System;
using ObjectLayoutInspector;

namespace DotNetTestProject
{
    /// <summary>
    /// 类型对象
    /// </summary>
    public class TypeObjectTests
    {
        /// <summary>
        /// 测试基类方法中通过this.GetType()获取实例的类型
        /// </summary>
        public void Test1()
        {
            new MyClass();  //DotNetTestProject.TypeObjectTests+MyClass
        }
        class MyBaseClass
        {
            public MyBaseClass()
            {
                Console.WriteLine(this.GetType());
            }
        }
        class MyClass : MyBaseClass
        {

        }

        public void Test2()
        {
            TypeLayout.PrintLayout(typeof(int).GetType());
            //Type layout for 'RuntimeType'
            //Size: 40 bytes.Paddings: 4 bytes(% 10 of empty space)
            //|======================================================|
            //|                Object Header(8 bytes)                |
            //|------------------------------------------------------|
            //|              Method Table Ptr(8 bytes)               |
            //|======================================================|
            //| 0 - 7: RemotingTypeCachedData m_cachedData(8 bytes)  |
            //|------------------------------------------------------|
            //| 8 - 15: Object m_keepalive(8 bytes)                  |
            //|------------------------------------------------------|
            //| 16 - 23: IntPtr m_cache(8 bytes)                     |
            //|------------------------------------------------------|
            //| 24 - 31: IntPtr m_handle(8 bytes)                    |
            //|------------------------------------------------------|
            //| 32 - 35: INVOCATION_FLAGS m_invocationFlags(4 bytes) |
            //|------------------------------------------------------|
            //| 36 - 39: padding(4 bytes)                            |
            //|======================================================|

        }
    }
}