using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class SettlementRermModel:BaseModel
    {

        /// <summary>
        /// 结算机构名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 结算账号
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 结算方式(0-划账、1-其它)
        /// </summary>
        public string SettlementMode { get; set; }

        /// <summary>
        /// 结算周期（天）
        /// </summary>
        public string SettlementCycle { get; set; }

        /// <summary>
        /// 0-消费、1-提现、2-红包、3-结算
        /// </summary>
        public string DealType { get; set; }

       /// <summary>
       /// 结算日期（日）
       /// </summary>
        public string Settlement { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string PageNum { get; set; }

        public string Days { get; set; }
    }
}
