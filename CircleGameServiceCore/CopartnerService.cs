using AutoMapper;
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
    public class CopartnerService : ICopartnerService
    {
        private readonly IMyInviteDetailService myInviteDetailService;
        private readonly ICircleWinnerRecordService circleWinnerRecordService;
        private readonly IMapper mapper;

        public CopartnerService(IMapper mapper,
            IMyInviteDetailService myInviteDetailService,
            ICircleWinnerRecordService circleWinnerRecordService)
        {
            this.myInviteDetailService = myInviteDetailService;
            this.mapper = mapper;
            this.circleWinnerRecordService = circleWinnerRecordService;
        }

        /// <summary>
        /// 获取到合伙人列表
        /// </summary>
        /// <returns></returns>

        public List<Copartner> GetCopartners()
        {
            String baseUrl = Config.GetBaseUrl();
            String inviteRankUrl = Config.GetInviteRankUrl();
            inviteRankUrl = inviteRankUrl + "?" + "startDate=" + Config.GetSelectedDateTime() + "&endDate=" + Config.GetSelectedDateTime() + "&circleId=" + Config.GetCircleId();
            var httpclientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            String cookie = LoginService.Cookie;
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

        /// <summary>
        /// 获取到当前合伙人收费
        /// </summary>
        /// <param name="copartnerPriceInput"></param>
        /// <returns></returns>
        public async Task<CopartnerPriceOutput> GetCopartnerPriceAsync(CopartnerPriceInput copartnerPriceInput)
        {
            double totalPrice = 0;
            double unitP = double.Parse(copartnerPriceInput.unitPrice);
            double doubleP = double.Parse(copartnerPriceInput.doubleUnitPrice);
            List<MyInviteDetail> myInviteDetails = await myInviteDetailService.GetMyInviteDetailsAsync(copartnerPriceInput.CopartnerID);

            if (myInviteDetailService == null || myInviteDetails.Count == 0)
            {
                throw new Exception("没有找到合伙人对应的邀请人信息");
            }
            for (int index = 0; index < myInviteDetails.Count; index++)
            {
                MyInviteDetail myInviteDetail = myInviteDetails[index];
                myInviteDetail.CopartnerID = copartnerPriceInput.CopartnerID;
                List<CircleWinnerRecord> circleWinnerRecords = await circleWinnerRecordService.GetWinnerRecordsAsync(copartnerPriceInput.CopartnerID, myInviteDetail.User_id);
                if (circleWinnerRecords == null)
                {
                    continue;
                }
                double everyInvitePrice = myInviteDetail.GetInvitePrice(circleWinnerRecords, unitP, doubleP);
                totalPrice += everyInvitePrice;
            }

            CopartnerPriceOutput copartnerPriceOutput = new CopartnerPriceOutput();
            copartnerPriceOutput.CopartnerID = copartnerPriceInput.CopartnerID;
            copartnerPriceOutput.CopartnerName = copartnerPriceInput.CopartnerName;
            copartnerPriceOutput.TotalPrice = totalPrice;
            List<MyInviteDetailOutput> myInviteDetailOutputs = mapper.Map<List<MyInviteDetailOutput>>(myInviteDetails);
            copartnerPriceOutput.MyInviteDetailOutputs = myInviteDetailOutputs;

            return copartnerPriceOutput;
        }
    }
}
