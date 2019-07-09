using System;

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
    }
}