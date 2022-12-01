using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace DgutAutoCheck
{
    /// <summary>
    /// 包装收发包的类
    /// </summary>
    internal class WebAuth : IDisposable
    {
        private const string preUrl = "https://yqfk-daka-api.dgut.edu.cn/new_login";

        /// <summary>
        /// 干活的客户端
        /// </summary>
        public HttpClient? Client { get; set; }
        /// <summary>
        /// 登陆页面url
        /// </summary>
        public string? LoginUrl { get; private set; }
        /// <summary>
        /// 需要用到的标记
        /// </summary>
        public string? ClientId { get; private set; }
        /// <summary>
        /// 打卡Url
        /// </summary>
        public string? CheckUrl { get; private set; }
        /// <summary>
        /// 上次打卡json
        /// </summary>
        public string? LastJson { get; private set; }

        /// <summary>
        /// 新建http客户端并不允许自动重定向
        /// </summary>
        public WebAuth()
        {
            Client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false
            });
        }

        /// <summary>
        /// 获取登录页面地址
        /// </summary>
        /// <returns>包括地址和之后用到的客户端id</returns>
        public void GetLoginInfo()
        {
            var json = Client!.GetAsync(preUrl).Result
                .Content.ReadAsStringAsync().Result;
            var url4ClientId1 = JsonSerializer.Deserialize<dynamic>(json)!
                .GetProperty("data")
                .GetProperty("url").ToString();
            var clientId = HttpUtility.ParseQueryString(new Uri(url4ClientId1.ToString()).Query).Get("client_id");
            var forDirection = $"https://auth.dgut.edu.cn/authserver/oauth2.0/authorize?response_type=code&client_id={clientId}&redirect_uri=https://yqfk-daka.dgut.edu.cn/new_login/dgut&state=yqfk";
            var url = Client!.GetAsync(forDirection).Result
                .Headers.GetValues("Location").First();
            LoginUrl = url;
            ClientId = clientId!;
        }

        /// <summary>
        /// 进行登陆操作并获得打卡页面地址
        /// </summary>
        /// <param name="info">登录地址</param>
        /// <param name="id">学号</param>
        /// <param name="password">密码</param>
        /// <returns>打卡地址</returns>
        public void Login(string id, string password)
        {
            // 从登陆页面获取密钥及execution
            var webHtml = Client!.GetAsync(LoginUrl).Result.Content.ReadAsStringAsync().Result;
            var page = new HtmlDocument();
            page.LoadHtml(webHtml);
            var key = page.DocumentNode.SelectSingleNode(@"//*[@id=""pwdEncryptSalt""]").GetAttributeValue("value", null);
            var pwd = Encrypt.EncryptWithAes(password, key);
            var exe = page.DocumentNode.SelectSingleNode(@"//*[@id=""execution""]").GetAttributeValue("value", null);

            // 制作post发送的数据集并发送
            Dictionary<string, string?> data = new()
            {
                {"username",id},
                {"password",pwd},
                {"captcha",""},
                {"_eventId","submit"},
                {"cllt","userNameLogin"},
                {"dllt","generalLogin"},
                {"lt",""},
                {"execution",exe},
                {"client_id",ClientId},
                {"redirect_uri","https://yqfk-daka.dgut.edu.cn/new_login/dgut"},
                {"respose_type","code"},
                {"client_name","CasOAuthClient"}
            };
            var sendingData = new FormUrlEncodedContent(data);
            var loginAuthUrl = "https://auth.dgut.edu.cn/authserver/login?service=https://auth.dgut.edu.cn/authserver/oauth2.0/callbackAuthorize";
            var result = Client.PostAsync(loginAuthUrl, sendingData).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.Redirect)
            {
                throw result.StatusCode switch
                {
                    System.Net.HttpStatusCode.Unauthorized => new LoginException("用户名或密码错误"),
                    _ => new LoginException(result.StatusCode.ToString()),
                };
            }

            // 经过多次重定向得到最终打卡地址
            var step1 = result.Headers.GetValues("Location").First();
            var then = Client.GetAsync(step1).Result;
            var step2 = then.Headers.GetValues("Location").First();
            var and = Client.GetAsync(step2).Result;

            // 注意此处token，将用于获取bearer认证
            var step3 = and.Headers.GetValues("Location").First();
            var token = HttpUtility.ParseQueryString(new Uri(step3).Query).Get("code");
            var bearerRequest = new Dictionary<string, string>
            {
                { "token", token! },
                { "state", "yqfk" }
            };
            var bearerResponse = Client
                .PostAsync("https://yqfk-daka-api.dgut.edu.cn/auth", new StringContent(JsonSerializer.Serialize(bearerRequest)))
                .Result.Content.ReadAsStringAsync().Result;
            var bearer = JsonSerializer.Deserialize<dynamic>(bearerResponse)!
                .GetProperty("access_token").ToString();
            Client.DefaultRequestHeaders.Add($"Authorization", $"Bearer {bearer}");
            var final = Client.GetAsync(step3).Result;
            var checkUrl = final.Content.ReadAsStringAsync().Result;
            CheckUrl = checkUrl;
        }

        /// <summary>
        /// 获取上次打卡数据
        /// </summary>
        public void GetLastJson()
        {
            var respond = Client!.GetAsync("https://yqfk-daka-api.dgut.edu.cn/record/").Result;
            LastJson = respond.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 打卡
        /// </summary>
        public void Check()
        {
            var json = new CheckData().CreateNew(LastJson!);
            var result = Client!.PostAsync("https://yqfk-daka-api.dgut.edu.cn/record/", new StringContent(json)).Result;
            var resultInfo = System.Text.RegularExpressions.Regex
                .Unescape(JsonSerializer.Deserialize<dynamic>(result.Content.ReadAsStringAsync().Result)!.GetProperty("message").ToString());
            if (!resultInfo.Contains("您今天已打卡成功！"))
            {
                throw new CheckException(resultInfo);
            }
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
