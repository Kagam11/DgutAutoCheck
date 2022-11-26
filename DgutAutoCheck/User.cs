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
        public static CustomProperty CustomProperty { get; set; }
    }

    /// <summary>
    /// 打卡数据处理类
    /// </summary>
    public class CheckData
    {
        public string Date { get; set; }
        public List<string> Properties { get; set; }
        public string CreateNew(string last)
        {
            dynamic obj = JsonSerializer.Deserialize<ExpandoObject>(last)!;
            IDictionary<string, object> item = JsonSerializer.Deserialize<ExpandoObject>(obj.user_data);
            IDictionary<string, object> result = new ExpandoObject()!;
            foreach (var property in Settings.CheckData.Properties)
            {
                result[property] = item[property];
            }
            foreach (var property in typeof(CustomProperty).GetProperties())
            {
                result[property.ToString()!] = ((IDictionary<string, object>)Settings.CustomProperty)[property.ToString()!];
            }
            return JsonSerializer.Serialize(result);
        }
    }
    /// <summary>
    /// 自定义提交字段
    /// </summary>
    public class CustomProperty
    {
#pragma warning disable IDE1006
        public double? body_temperature { get; set; }
        public int? health_situation { get; set; }
        public int? is_in_school { get; set; }
        public string? now_detail_address_name { get; set; }
#pragma warning restore IDE1006
    }
    #region 登录相关
#pragma warning disable IDE1006 // 别烦
#pragma warning disable CS8618
    /// <summary>
    /// 获取登陆页面时获取的json
    /// </summary>
    public class LoginRespond
    {
        public LoginUrlData data { get; set; }
    }
    /// <summary>
    /// 获取登陆页面时获取json里面的数据
    /// </summary>
    public class LoginUrlData
    {
        public string url { get; set; }
    }
    /// <summary>
    /// 获取bearer认证用
    /// </summary>
    public class BearerRequest
    {
        public string token { get; set; }
        public string state { get; set; }
    }
    /// <summary>
    /// 获取bearer的返回值
    /// </summary>
    public class BearerResponse
    {
        public string access_token { get; set; }
    }
    /// <summary>
    /// 打卡结果
    /// </summary>
    public class CheckResponse
    {
        public string message { get; set; }
    }
#pragma warning restore CS8618
#pragma warning restore IDE1006
    #endregion
    
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
