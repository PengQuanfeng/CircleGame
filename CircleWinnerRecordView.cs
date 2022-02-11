using CircleGameModel;
using CircleGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    /// <summary>
    /// 合伙人对应被邀请人牌局信息管理
    /// </summary>
    public class CircleWinnerRecordView
    {
        public List<CircleWinnerRecord> GetWinnerRecords(String copartnerId,String userId)
        {
            CircleWinnerRecordService circleWinnerRecordService = new CircleWinnerRecordService();
            return circleWinnerRecordService.GetWinnerRecords(copartnerId,userId);
        }
    }
}
