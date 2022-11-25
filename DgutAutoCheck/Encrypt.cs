using System.Security.Cryptography;
using System.Text;

namespace DgutAutoCheck
{
    /// <summary>
    /// 处理密码的加密
    /// </summary>
    internal class Encrypt
    {
        /// <summary>
        /// 获取系统加了盐之后的密码
        /// </summary>
        /// <param name="password">原密码</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string EncryptWithAes(string password, string key)
        {
            using var aes = Aes.Create();
            aes.KeySize = 128; // AES128
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.BlockSize = 128;
            aes.Key = Encoding.ASCII.GetBytes(key);
            // 懒得写随机，让他们固定吧
            var passwordBytes = Encoding.UTF8.GetBytes($"おぼろに霞む春のつき このおもい風と舞い散れ{password}");
            var encrypted = aes.EncryptCbc(passwordBytes, Encoding.UTF8.GetBytes("はつね ミク"));
            return Convert.ToBase64String(encrypted);
        }
    }
}
