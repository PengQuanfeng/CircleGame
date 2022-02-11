using CircleGameConfig;
using CircleGameModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CircleGameService
{
    public class LoginService
    {
        public static String cookie = String.Empty;

        public static String Cookie
        {
            get
            {
                if (String.IsNullOrEmpty(cookie))
                {
                    cookie = Login();
                }
                return cookie;
            }
        }

        private static String Login()
        {
            try
            {
                var httpclientHandler = new HttpClientHandler();
                httpclientHandler.UseCookies = true;

                var loginContent = new FormUrlEncodedContent(new[]
                {
                     new KeyValuePair<string,string>("mobile", Config.GetMobile()),
                     new KeyValuePair<string, string>("password",Config.GetPassword()),
                     new KeyValuePair<string, string>("type",Config.GetTypeInfo())
                });
                String baseUrl = Config.GetBaseUrl();
                String loginUrl = Config.GetLoginUrl();
                using (var httpClient = new HttpClient(httpclientHandler))
                {
                    // 先登陆
                    Log4Helper.Info(typeof(LoginService), "【开始登录】");
                    var loginResult = httpClient.PostAsync(baseUrl + loginUrl, loginContent);
                    // 登陆成功后，客户端会自动携带 cookie ，不需要再手动添加
                    if (loginResult.Result.IsSuccessStatusCode)
                    {
                        /*
                         * 如果请求成功
                         */
                        Log4Helper.Info(typeof(LoginService), "【登录成功】");
                        System.Console.WriteLine("登录成功!");
                    }

                    var cookie = loginResult.Result.Headers.GetValues("Set-Cookie").First();
                    return cookie;
                }
            }
            catch (Exception ex)
            {
                Log4Helper.Error(typeof(LoginService), ex.Message);
            }

            throw new Exception("登录失败.");
        }
    }
}
