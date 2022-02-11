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
    public class CircleWinnerRecordService
    {
        /// <summary>
        /// 最大赢家牌局列表
        /// </summary>
        /// <param name="copartnerId">邀请人</param>
        /// <param name="userId">被邀请人</param>
        /// <returns></returns>
        public List<CircleWinnerRecord> GetWinnerRecords(String copartnerId,String userId)
        {
            String baseUrl = Config.GetBaseUrl();
            String winnerRecordUrl = Config.GetWinnerRecord();
            winnerRecordUrl = winnerRecordUrl + "?" + "startDate=" + Config.GetSelectedDateTime() + "&endDate=" + Config.GetSelectedDateTime() +"&user_id="+userId+ "&inviter_uid=" + copartnerId + "&circle_id=" + Config.GetCircleId();
            var httpclientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            String cookie = LoginService.Cookie;
            using (var httpClient = new HttpClient(httpclientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                var circleWinnerRecordResult = httpClient.GetAsync(baseUrl + winnerRecordUrl);
                String circleWinnerRecordInfo = circleWinnerRecordResult.Result.Content.ReadAsStringAsync().Result;
                CircleWinnerRecordData circleWinnerRecordData = JsonConvert.DeserializeObject<CircleWinnerRecordData>(circleWinnerRecordInfo);
                System.Console.WriteLine(circleWinnerRecordData);
                Log4Helper.Info(this.GetType(), "【成功获取合伙人对应被邀请人牌局列表信息】");
                httpClient.Dispose();
                return circleWinnerRecordData.data;
            }
        }
    }
}
