namespace DgutAutoCheck
{
    /// <summary>
    /// 记录数据类
    /// </summary>
    internal class Record
    {
        public static string Log { get; set; } = "";
        /// <summary>
        /// 学号
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// 打卡是否成功
        /// </summary>
        public bool IsSuccess { get; set; } = true;
        /// <summary>
        /// 失败原因
        /// </summary>
        public string? FailResaon { get; set; } = null;

        public static void MakeLog(string text)
        {
            Console.WriteLine(text);
            Log += "\r\n";
            Log += text;
        }

        public static void Write(string path, string text)
        {
            using var writer = File.AppendText(path);
            writer.Write(text);
        }
    }
    /// <summary>
    /// 设置
    /// </summary>
    public class Config
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
}
