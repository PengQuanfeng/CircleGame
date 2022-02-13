using CircleGameConfig;
using CircleGameModel;
using ICircleGameServiceCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CircleGameService
{
    public class MyInviteDetailService : IMyInviteDetailService
    {
        /// <summary>
        /// 获取到合伙对应被邀请人列表
        /// </summary>
        /// <param name="copartnerId">邀请人</param>
        /// <returns></returns>
        public async Task<List<MyInviteDetail>> GetMyInviteDetailsAsync(String copartnerId)
        {
            String baseUrl = Config.GetBaseUrl();
            String myInviteDetailUrl = Config.GetMyInviteDetail();
            myInviteDetailUrl = myInviteDetailUrl + "?" + "startDate=" + Config.GetSelectedDateTime() + "&endDate=" + Config.GetSelectedDateTime() + "&inviterUid=" + copartnerId + "&circleId=" + Config.GetCircleId();
            var httpclientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            String cookie = LoginService.Cookie;
            using (var httpClient = new HttpClient(httpclientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                var myInviteDetailResult = httpClient.GetAsync(baseUrl + myInviteDetailUrl);
                String myInviteDetailInfo = await myInviteDetailResult.Result.Content.ReadAsStringAsync();
                MyInviteDetailData myInviteDetailData = JsonConvert.DeserializeObject<MyInviteDetailData>(myInviteDetailInfo);
                System.Console.WriteLine(myInviteDetailData);
                Log4Helper.Info(this.GetType(), "【成功获取合伙人对应被邀请人列表】");
                httpClient.Dispose();
                return myInviteDetailData.data;
            }
        }
    }
}
