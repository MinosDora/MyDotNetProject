using System;

namespace MinoTool
{
    /// <summary>
    /// 枚举工具类
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// 获取枚举的名称字符串
        /// XXX 有装箱
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enum">枚举实例</param>
        /// <returns></returns>
        public static string GetName<T>(Enum @enum) where T : Enum
        {
            return Enum.GetName(typeof(T), @enum);
        }
    }
}