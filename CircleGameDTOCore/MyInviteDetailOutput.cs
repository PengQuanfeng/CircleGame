using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 邀请人对应被邀请人信息
    /// </summary>
    public class MyInviteDetailOutput
    {
        /// <summary>
        /// 合伙人标识
        /// </summary>
        public String CopartnerID { get; set; }

        /// <summary>
        /// 被邀请人标识
        /// </summary>
        public String User_id { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public String Avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public String Nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Consume { get; set; }
        /// <summary>
        /// 牌局数
        /// </summary>
        public String Round { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public String Score { get; set; }
        /// <summary>
        /// 最大赢家次数
        /// </summary>
        public String Win_count { get; set; }

        /// <summary>
        /// 单赢家次数
        /// </summary>
        public int Win_count1 { get; set; }

        /// <summary>
        /// 双赢家次数
        /// </summary>
        public String Win_count2 { get; set; }
        /// <summary>
        /// 三赢家次数
        /// </summary>
        public String Win_count3 { get; set; }

        /// <summary>
        /// 打两盘牌局的赢的数量
        /// </summary>
        public int TwoPerson_Win_count { get; set; } = 0;

        /// <summary>
        /// 当前受邀人打两盘牌局所需付的费用
        /// </summary>
        public double TwoPersonPrice { get; set; } = 0;

        /// <summary>
        /// 当前受邀人单盈所需付的费用 包含两人和四人
        /// </summary>
        public double Win_count1Price { get; set; } = 0;

        /// <summary>
        /// 单盈(四人)人数数量
        /// </summary>
        public int Win_count1ForFourPerson { get; set; }

        /// <summary>
        /// 当前受邀人单盈(四人)所需付的费用
        /// </summary>
        public double Win_count1PriceForFourPerson { get; set; }

        /// <summary>
        /// 当前受邀人两盈所需付的费用
        /// </summary>
        public double Win_count2Price { get; set; } = 0;

        // <summary>
        /// 当前受邀人三盈所需付的费用
        /// </summary>
        public double Win_count3Price { get; set; } = 0;

        /// <summary>
        /// 当前受邀人要付的费用
        /// </summary>
        public double EveryInvitePrice { get; set; } = 0;
    }
}
