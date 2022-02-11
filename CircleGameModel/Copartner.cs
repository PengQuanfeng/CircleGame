using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 合伙人信息
    /// </summary>
    public class Copartner
    {
        /// <summary>
        /// 合伙人标识
        /// </summary>
        public String _id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Calc_score { get; set; }
        /// <summary>
        /// 合伙人缩略图
        /// </summary>
        public String Inviter_avatar{ get; set; }
        /// <summary>
        /// 合伙人昵称
        /// </summary>
        public String Inviter_nickname { get; set; }
        /// <summary>
        /// 合伙人唯一标识
        /// </summary>
        public String Inviter_uid { get; set; }
        /// <summary>
        /// 牌局数
        /// </summary>
        public String Round { get; set; }
        /// <summary>
        /// 所以牌局占比
        /// </summary>
        public String Round_percent  { get; set; }
        /// <summary>
        /// 邀请总数
        /// </summary>
        public String Total_invitee { get; set; }
        /// <summary>
        /// 最大赢家次数
        /// </summary>
        public String Win_count { get; set; }
        /// <summary>
        /// 双赢家次数
        /// </summary>
        public String Win_count2  { get; set; }
        /// <summary>
        /// 三赢家次数
        /// </summary>
        public String Win_count3 { get; set; }

    }
}
