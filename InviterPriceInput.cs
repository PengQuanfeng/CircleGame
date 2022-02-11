using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 价格基数
    /// </summary>
    public class InviterPriceInput
    {
        /// <summary>
        /// 计算的行序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 合伙人唯一标识
        /// </summary>
        public String Inviter_uid { get; set; }
       
        /// <summary>
        /// 双人对战价格基数
        /// </summary>
        public String UnitPrice { get; set; }
        /// <summary>
        /// 四人对战价格基数
        /// </summary>
        public String DoublePrice { get; set; }

        /// <summary>
        /// 总费用
        /// </summary>
        public double TotalPrice { get; set; }
    }
}
