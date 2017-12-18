using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class DealDetailedModel:BaseModel
    {
        /// <summary>
        /// 交易单号
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string DealStatement { get; set; }

        /// <summary>
        /// 收款用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 收款银行账号
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 收款机构名称
        /// </summary>
        public string PayeeInstitution { get; set; }

        /// <summary>
        /// 银行流水号
        /// </summary>
        public string BankStatement { get; set; }

        /// <summary>
        /// 交易请求时间
        /// </summary>
        public string RequestTime { get; set; }

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string TradeTime { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public string DealMoney { get; set; }

        /// <summary>
        /// 支付状态（0-未到账、1-已到账）
        /// </summary>
        public string DealStatus { get; set; }
    }
}
