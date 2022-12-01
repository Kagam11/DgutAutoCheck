using System.Dynamic;
using System.Text.Json;

namespace DgutAutoCheck
{
    /// <summary>
    /// 需打卡用户
    /// </summary>
    internal class User
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }
    }
    /// <summary>
    /// 设置
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// 出现失败后是否发送邮件
        /// </summary>
        public bool SendEmailIfAnyFail { get; set; }
        /// <summary>
        /// 发件箱
        /// </summary>
        public string? From { get; set; }
        /// <summary>
        /// 收件箱
        /// </summary>
        public string? To { get; set; }
        /// <summary>
        /// smtp密码
        /// </summary>
        public string? SmtpPassword { get; set; }
        /// <summary>
        /// smtp服务器
        /// </summary>
        public string? SmtpServer { get; set; }
        /// <summary>
        /// smtp端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 是否存储打卡json
        /// </summary>
        public bool IsSaveJson { get; set; }
    }
    public static class Settings
    {
        public static Configuration Config { get; set; }
        public static CheckData CheckData { get; set; }
        public static Dictionary<string, object> CustomProperty { get; set; }
    }

    /// <summary>
    /// 打卡数据处理类
    /// </summary>
    public class CheckData
    {
        public string Date { get; set; }
        public List<string> Properties { get; set; }
        public static string CreateNew(string last)
        {
            dynamic obj = JsonSerializer.Deserialize<ExpandoObject>(last)!;
            IDictionary<string, object> item = JsonSerializer.Deserialize<ExpandoObject>(obj.user_data);
            IDictionary<string, object> result = new ExpandoObject()!;
            foreach (var property in Settings.CheckData.Properties)
            {
                result[property] = item[property];
            }
            foreach (var key in Settings.CustomProperty.Keys)
            {
                result[key] = Settings.CustomProperty[key];
            }
            return $"{{\"data\": {JsonSerializer.Serialize(result)}}}";
        }
    }

    #region 异常处理类
    /// <summary>
    /// 打卡时错误
    /// </summary>
    public class CheckException : Exception
    {
        public CheckException(string? message) : base(message) { }
    }
    /// <summary>
    /// 登录时错误
    /// </summary>
    public class LoginException : Exception
    {
        public LoginException(string? message) : base(message) { }
    }
    #endregion
}
