using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModel;

namespace AppModel
{
   public class WalletModel:BaseModel
    {

        /// <summary>
        /// 钱包用户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户余额
        /// </summary>
        public string balance { get; set; }

        /// <summary>
        /// 实名认证 0-未认证，1-已认证
        /// </summary>
        public string Certification { get; set; }

        /// <summary>
        /// 手机号（旧手机号）
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 新手机号
        /// </summary>
        public string NewPhoneNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 绑定第三方支付数量
        /// </summary>
        public string EscrowNum { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNum { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 第三方支付标识 0-微信 1-支付宝
        /// </summary>
        public string EscrowIdentify { get; set; }

        /// <summary>
        /// (微信)OpenID
        /// </summary>
        public string OpenId { get; set; }
    }
}
