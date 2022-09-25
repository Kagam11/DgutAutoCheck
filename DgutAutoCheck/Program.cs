using DgutAutoCheck;
using System.Text.Json;

var config = GetConfig();
var records = new List<Record>();
var users = GetUsers();

Record.MakeLog("开始打卡");
Record.MakeLog($"发现 {users.Count} 个用户需打卡");
Record.MakeLog("===============================");
foreach (var user in users)
{
    var record = new Record()
    {
        Username = user.Username
    };
    try
    {

        Record.MakeLog($"正在打卡：{user.Username}");
        using var webAuth = new WebAuth();
        webAuth.GetLoginInfo();
        webAuth.Login(user.Username!, user.Password!);
        webAuth.GetLastJson();
        if (config.IsSaveJson) Record.Write($"./Json/{DateTime.Now:yyyy-MM-dd HH-mm}-{user.Username}.txt", webAuth.LastJson!);
        webAuth.Check();
        Record.MakeLog($"{user.Username} 打卡成功");
    }
    catch (Exception ex)
    {
        switch (ex)
        {
            case LoginException l:
                Record.MakeLog($"{user.Username} 登录错误：{l.Message}");
                record.IsSuccess = false;
                break;
            case CheckException c:
                Record.MakeLog($"{user.Username} 打卡错误：{c.Message}");
                record.IsSuccess = false;
                break;
            default:
                Record.MakeLog($"{user.Username} 未知错误：{ex.Message}");
                record.IsSuccess = false;
                break;
        }
    }
    finally
    {
        records.Add(record);
    }
}
Record.MakeLog("===============================");
Record.MakeLog("所有用户打卡完毕");
Record.MakeLog("");
if (!records.Any(item => item.IsSuccess == false))
{
    Record.MakeLog("没有异常，好耶");
}
else
{
    Record.MakeLog($"存在 {records.Count(item => item.IsSuccess == false)} 个用户打卡异常：");
    foreach (var record in records)
    {
        if (record.IsSuccess == false) Record.MakeLog($"{record.Username}: {record.FailResaon}");
    }
}
Record.Write($"./Log/{DateTime.Now:yyyy-MM-dd HH-mm}.txt", Record.Log);
if (records.Any(item => item.IsSuccess == false))
{
    try
    {
        if (config.SendEmailIfAnyFail)
        {
            var alert = new Alert(config);
            alert.From = config.From;
            alert.To = config.To;
            alert.SendMail(Record.Log);
        }
    }
    catch { }
}


Config GetConfig()
{
#if !DEBUG
    var path = "./Config.json";
#else
    var path = "./Config_debug.json";
#endif
    return Deserialize<Config>(new StreamReader(path).ReadToEnd())!;
}
List<User> GetUsers()
{
#if !DEBUG
    var path = "./Users.json";
#else
    var path = "./Users_debug.json";
#endif
    return Deserialize<List<User>>(new StreamReader(path).ReadToEnd())!;
}

T Deserialize<T>(string json) where T : class
{
    var option = new JsonSerializerOptions
    {
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    return JsonSerializer.Deserialize<T>(json, option)!;
}