using DgutAutoCheck;
using System.Text.Json;

var records = new List<Record>();
var users = new List<User>();

try
{
    Settings.Config = GetJson<Configuration>("Config");
    users = GetJson<List<User>>("Users");
    Settings.CustomProperty = GetJson<CustomProperty>("Custom");
    Settings.CheckData = GetJson<CheckData>("UploadProperties");
}
catch(Exception ex)
{
    Record.MakeLog("json文件读取失败，检查是否填写错误");
    Record.MakeLog(ex.Message);
    Record.Write($"./Log/{DateTime.Now:yyyy-MM-dd HH-mm}.txt", Record.Log);
    return;
}

Record.MakeLog("开始打卡");
Record.MakeLog($"发现 {users.Count} 个用户需打卡");
Record.MakeLog("===============================");
foreach (var user in users)
{
    // 对打卡结果进行记录
    var record = new Record()
    {
        Username = user.Username
    };

    try // 登录并打卡
    {
        Record.MakeLog($"正在打卡：{user.Username}");
        using var webAuth = new WebAuth();
        webAuth.GetLoginInfo();
        webAuth.Login(user.Username!, user.Password!);
        webAuth.GetLastJson();
        
        if (Settings.Config.IsSaveJson) Record.Write($"./Json/{DateTime.Now:yyyy-MM-dd HH-mm}-{user.Username}.txt", webAuth.LastJson!);
        
        webAuth.Check(Settings.CustomProperty);
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
if (records.All(item => item.IsSuccess))
{
    Record.MakeLog("没有异常，好耶");
}
else
{
    Record.MakeLog($"存在 {records.Count(item => item.IsSuccess == false)} 个用户打卡异常：");
    foreach (var record in records.Where(record => record.IsSuccess == false))
    {
        Record.MakeLog($"{record.Username}: {record.FailReason}");
    }
}

Record.Write($"./Log/{DateTime.Now:yyyy-MM-dd HH-mm}.txt", Record.Log);
if (records.Any(item => item.IsSuccess == false))
{
    try
    {
        if (Settings.Config.SendEmailIfAnyFail)
        {
            var alert = new Alert(Settings.Config)
            {
                From = Settings.Config.From,
                To = Settings.Config.To
            };
            alert.SendMail(Record.Log);
        }
    }
    catch { }
}

// 从json获取实例
T GetJson<T>(string name) where T : class
{
#if !DEBUG
    var path = $"./{name}.json";
#else
    var path = $"./{name}_debug.json";
#endif
    return Deserialize<T>(new StreamReader(path).ReadToEnd())!;
}

// 兼容注释的反序列化
T Deserialize<T>(string json) where T : class
{
    var option = new JsonSerializerOptions
    {
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    return JsonSerializer.Deserialize<T>(json, option)!;
}