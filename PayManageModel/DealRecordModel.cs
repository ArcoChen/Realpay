using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class DealRecordModel:BaseModel
    {
        /// <summary>
        /// 交易单号
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 交易类型（0-消费、1-提现、2-红包、3-结算）
        /// </summary>
        public string DealType { get; set; }

        /// <summary>
        /// 支付机构名称
        /// </summary>
        public string PayInstitustion { get; set; }

        /// <summary>
        /// 支付账号
        /// </summary>
        public string PayAccount { get; set; }

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
        /// 支付状态（0-未支付、1-已支付、2-已确认、3-暂停交易）
        /// </summary>
        public string DealStatus { get; set; }
    }
}
