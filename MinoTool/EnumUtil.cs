using System;

namespace MinoTool
{
    /// <summary>
    /// 枚举工具类
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// 获取枚举的名称
        /// XXX 有装箱
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumValue">枚举实例</param>
        /// <returns>枚举的名称</returns>
        public static string GetName<T>(T enumValue) where T : struct, Enum
        {
            return Enum.GetName(typeof(T), enumValue);
        }

        /// <summary>
        /// 根据字符串获取枚举值，转换失败返回枚举类型的默认值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumStr">枚举字符串</param>
        /// <returns>枚举值</returns>
        public static T GetEnum<T>(string enumStr) where T : struct, Enum
        {
            if (Enum.TryParse(enumStr, out T enumValue))
            {
                return enumValue;
            }
            return default;
        }

        /// <summary>
        /// 根据字符串获取枚举数，转换失败返回枚举基本类型的默认值
        /// XXX 有装箱
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <typeparam name="U">枚举基本类型</typeparam>
        /// <param name="enumStr">枚举字符串</param>
        /// <returns>枚举数</returns>
        public static U GetValue<T, U>(string enumStr) where T : struct, Enum where U : struct
        {
            object enumValue = GetEnum<T>(enumStr);
            return (U)enumValue;
        }
    }
}