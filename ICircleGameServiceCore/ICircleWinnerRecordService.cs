using CircleGameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CircleGameService
{
    public interface ICircleWinnerRecordService
    {
        /// <summary>
        /// 最大赢家牌局列表
        /// </summary>
        /// <param name="copartnerId">邀请人</param>
        /// <param name="userId">被邀请人</param>
        /// <returns></returns>
        public Task<List<CircleWinnerRecord>> GetWinnerRecordsAsync(String copartnerId, String userId);
    }
}
