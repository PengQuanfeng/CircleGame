using CircleGameModel;
using CircleGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    /// <summary>
    /// 合伙人对应被邀请人信息管理
    /// </summary>
    public class MyInviteDetailView
    {
        public List<MyInviteDetail> GetMyInviteDetails(String copartnerId)
        {
            MyInviteDetailService myInviteDetailService = new MyInviteDetailService();
            return myInviteDetailService.GetMyInviteDetails(copartnerId);
        }
    }
}
