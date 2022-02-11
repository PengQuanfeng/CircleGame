using CircleGameModel;
using CircleGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    /// <summary>
    /// 合伙人信息管理
    /// </summary>
    public class CopartnerView
    {
        public List<Copartner> GetCopartners()
        {
            CopartnerService copartnerService = new CopartnerService();
            return  copartnerService.GetCopartners();
        }
    }
}
