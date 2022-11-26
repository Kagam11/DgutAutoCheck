using System.Net;
using System.Net.Mail;

namespace DgutAutoCheck
{
    /// <summary>
    /// 发邮件告警类
    /// </summary>
    internal class Alert
    {
        private readonly SmtpClient? smtp;
        public string? From { private get; set; }
        public string? To { private get; set; }
        public Alert(Configuration configuration)
        {
            smtp = new SmtpClient(configuration.SmtpServer, configuration.Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(configuration.From, configuration.SmtpPassword)
            };
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="message">正文</param>
        public void SendMail(string message)
        {
            if (string.IsNullOrEmpty(To)) To = From;
            var mail = new MailMessage(From!, To!)
            {
                Subject = "打卡异常",
                Body = message
            };
#if !DEBUG
            smtp!.Send(mail);
#endif
        }
    }
}
