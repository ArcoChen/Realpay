using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class DealCheckModel:BaseModel
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
        /// 当前平台账户余额
        /// </summary>
        public string PlatformBalance { get; set; }

        /// <summary>
        /// 平台银行实际余额
        /// </summary>
        public string BankBalance { get; set; }

        /// <summary>
        /// 对账日期
        /// </summary>
        public string CheckTime { get; set; }

        /// <summary>
        /// 对账结果（0-正常、1-平台异常、2-本地异常）
        /// </summary>
        public string CheckResult { get; set; }

        public string StartTime { get; set; }
        
        public string EndTime { get; set; }

        public string PageNum { get; set; }
    }
}
