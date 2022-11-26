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
        public string? FailReason { get; set; } = null;

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
}
