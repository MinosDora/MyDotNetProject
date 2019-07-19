using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MinoTool
{
    /// <summary>
    /// MD5工具类
    /// </summary>
    public static class MD5Util
    {
        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] md5Bytes = md5.ComputeHash(fileStream);
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < md5Bytes.Length; i++)
                    {
                        stringBuilder.Append(md5Bytes[i].ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" + e.Message);
            }
        }
    }
}
