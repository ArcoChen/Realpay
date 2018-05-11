using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public  class UserBankModel:BaseModel
    {

        /// <summary>
        /// 支付机构名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 支付账号
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public string AccountState { get; set; }

        /// <summary>
        /// 开户网点    
        /// </summary>
        public string OpeningPoint { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户身份证
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public string RegisterTime { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public string UserBalance { get; set; }

        /// <summary>
        /// 单笔限额
        /// </summary>
        public string SingleLimit { get; set; }

        /// <summary>
        /// 单日限额
        /// </summary>
        public string DayLimit { get; set; }
    }
}
