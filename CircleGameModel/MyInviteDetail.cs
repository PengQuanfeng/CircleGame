using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 邀请人对应被邀请人信息
    /// </summary>
    public class MyInviteDetail
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
        public int Win_count1ForFourPerson
        {
            get
            {
                int win_count1 = Win_count1;
                return win_count1 - TwoPerson_Win_count;
            }
        }

        /// <summary>
        /// 当前受邀人单盈(四人)所需付的费用
        /// </summary>
        public double Win_count1PriceForFourPerson
        {
            get
            {
                return Win_count1Price - TwoPersonPrice;
            }
        }

        /// <summary>
        /// 当前受邀人两盈所需付的费用
        /// </summary>
        public double Win_count2Price{get; set;} = 0;

        // <summary>
        /// 当前受邀人三盈所需付的费用
        /// </summary>
        public double Win_count3Price { get; set; } = 0;

        /// <summary>
        /// 当前受邀人要付的费用
        /// </summary>
        public double EveryInvitePrice { get; set; } = 0;

        /// <summary>
        /// 受邀人所有牌局要付的费用
        /// </summary>
        /// <param name="circleWinnerRecords"></param>
        /// <param name="unitPrice"></param>
        /// <param name="doublePrice"></param>
        /// <returns></returns>
        public double GetInvitePrice(List<CircleWinnerRecord> circleWinnerRecords, double unitPrice, double doublePrice)
        {
            double everyInvitePrice = 0;

            if (circleWinnerRecords != null)
            {
                for (int winnerRecordIndex = 0; winnerRecordIndex < circleWinnerRecords.Count; winnerRecordIndex++)
                {
                    CircleWinnerRecord circleWinnerRecord = circleWinnerRecords[winnerRecordIndex];
                    if (circleWinnerRecord == null || circleWinnerRecord.record == null || circleWinnerRecord.record.Count <= 0)
                    {
                        continue;
                    }
                    circleWinnerRecord.UserId = User_id;
                    double everyCirclePrice = circleWinnerRecord.GetCirclePrice(unitPrice, doublePrice);
                    if(!circleWinnerRecord.IsFourPerson) //两人局
                    {
                        Win_count1 += 1;
                        TwoPerson_Win_count += 1;
                        Win_count1Price += everyCirclePrice;
                        TwoPersonPrice += everyCirclePrice;
                    }
                    else//四人局
                    {
                        if(circleWinnerRecord.IsOneWinner)
                        {
                            Win_count1 += 1;
                            Win_count1Price += everyCirclePrice;
                        }
                        if (circleWinnerRecord.IsTwoWinner)
                        {
                            Win_count2 += 1;
                            Win_count2Price += everyCirclePrice;
                        }
                        if (circleWinnerRecord.IsThreeWinner)
                        {
                            Win_count3 += 1;
                            Win_count3Price += everyCirclePrice;
                        }
                    }

                    everyInvitePrice += everyCirclePrice;
                }
            }
            EveryInvitePrice = everyInvitePrice;
            return everyInvitePrice;
        }
    }
}
