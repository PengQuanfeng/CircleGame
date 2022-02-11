using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 被邀请人赢钱记录
    /// </summary>
    public class WinnerRecord
    {
        /// <summary>
        /// 被邀请人标识
        /// </summary>
        public String User_id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public String Nickname { get; set; }
        /// <summary>
        /// 盈利分数
        /// </summary>
        public String Win_gold { get; set; }
    }
}
