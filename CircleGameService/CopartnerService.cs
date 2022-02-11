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
    public class CopartnerService
    {
        /// <summary>
        /// 获取到合伙人列表
        /// </summary>
        /// <returns></returns>
        public List<Copartner> GetCopartners()
        {
            String baseUrl = Config.GetBaseUrl();
            String inviteRankUrl= Config.GetInviteRankUrl();
            inviteRankUrl = inviteRankUrl + "?" + "startDate=" + Config.GetSelectedDateTime() + "&endDate=" + Config.GetSelectedDateTime() + "&circleId=" + Config.GetCircleId();
            var httpclientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            String cookie= LoginService.Cookie;
            using (var httpClient = new HttpClient(httpclientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                var inviteRankResult = httpClient.GetAsync(baseUrl + inviteRankUrl);
                String inviteRankInfo = inviteRankResult.Result.Content.ReadAsStringAsync().Result;
                CopartnerData copartnerData = JsonConvert.DeserializeObject<CopartnerData>(inviteRankInfo);
                System.Console.WriteLine(copartnerData);
                Log4Helper.Info(this.GetType(), "【成功获取合伙人列表】");
                httpClient.Dispose();
                return copartnerData.data;
            }
        }

        
    }
}
