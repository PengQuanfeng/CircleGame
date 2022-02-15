using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGameModel
{
    /// <summary>
    /// 合伙人费用计算
    /// </summary>
    public class CopartnerPriceInput
    {
        /// <summary>
        /// 合伙人标识
        /// </summary>
        public String CopartnerID { get; set; }

        /// <summary>
        /// 合伙人名称
        /// </summary>
        public String CopartnerName { get; set; }

        /// <summary>
        /// 总费用
        /// </summary>
        public String unitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String doubleUnitPrice { get; set; }
    }
}
