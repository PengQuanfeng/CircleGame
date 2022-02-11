using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 一桌牌局情况
    /// </summary>
    public class CircleWinnerRecord
    {
        /// <summary>
        /// 赢家数
        /// </summary>
        private int _winCount = 0;

        /// <summary>
        /// 赢家数
        /// </summary>
        public int WinCount
        {
            get
            {
                //还没初始化
                if (_winCount == 0)
                {
                    _winCount = GetWinCount();
                }
                return _winCount;
            }
        }

        /// <summary>
        /// 主场打牌人标识
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 开始牌局时间
        /// </summary>
        public DateTime Begintime { get; set; }
        /// <summary>
        /// 结束牌局时间
        /// </summary>
        public DateTime Endtime { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Stats_day { get; set; }

        /// <summary>
        /// 当前牌局所有人
        /// </summary>
        public List<WinnerRecord> record { get; set; }

        /// <summary>
        /// 是否是四人局
        /// </summary>
        /// <param name="circleWinnerRecord"></param>
        /// <returns></returns>
        public bool IsFourPerson
        {
            get
            {
                return record.Count == 4;
            }
        }

        /// <summary>
        /// 是否是单赢家
        /// </summary>
        public bool IsOneWinner
        {
            get
            {
                return WinCount == 1;
            }
        }

        /// <summary>
        /// 是否是双赢家
        /// </summary>
        public bool IsTwoWinner
        {
            get
            {
                if (IsFourPerson)
                {
                    return WinCount == 2;
                }
                return false;
            }
        }

        /// <summary>
        /// 是否是三赢家
        /// </summary>
        public bool IsThreeWinner
        {
            get
            {
                if (IsFourPerson)
                {
                    return WinCount == 3;
                }
                return false;
            }
        }

        /// <summary>
        /// 获取赢家数
        /// </summary>
        /// <returns></returns>
        private int GetWinCount()
        {
            int maxWinGold = int.MinValue;
            int winCount = 0;
            for (int index = 0; index < record.Count; index++)
            {
                WinnerRecord winnerRecord = record[index];
                int currentWinGold = int.Parse(winnerRecord.Win_gold);
                if (currentWinGold == maxWinGold)
                {
                    winCount++;
                }
                if (currentWinGold > maxWinGold)
                {
                    maxWinGold = currentWinGold;
                    winCount = 1;
                }
            }
            return winCount;
        }

        /// <summary>
        /// 获取到指定玩家
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public WinnerRecord GetWinnerRecord(String userId)
        {
            WinnerRecord winnerRecord = record.Find(w => w.User_id.Equals(userId));
            return winnerRecord;
        }

        private double _everyCirclePrice = -1;

        /// <summary>
        /// 一盘牌局需要付的费用
        /// </summary>
        public double EveryCirclePrice
        {
            get
            {
                return _everyCirclePrice;
            }
        }

        /// <summary>
        /// 一局当前人要付的费用
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <param name="doublePrice"></param>
        /// <returns></returns>
        public double GetCirclePrice(double unitPrice, double doublePrice)
        {
            double everyCirclePrice = 0;
            if (!IsFourPerson)
            {
                //两人局
                WinnerRecord winnerRecord = GetWinnerRecord(UserId);
                //只在当前赢家盈利1个子以上才收钱
                if (int.Parse(winnerRecord.Win_gold) > 1)
                {
                    everyCirclePrice = unitPrice;
                }
            }
            else
            {//四人局
             //单赢家
                if (IsOneWinner)
                {
                    everyCirclePrice = doublePrice;
                }
                //双赢家
                if (IsTwoWinner)
                {
                    everyCirclePrice = doublePrice / 2.0;
                }
                //三赢家
                if (IsThreeWinner)
                {
                    everyCirclePrice = doublePrice / 3.0;
                }
            }
            _everyCirclePrice = everyCirclePrice;
            return everyCirclePrice;
        }
    }
}
