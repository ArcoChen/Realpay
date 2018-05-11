using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class PaymentModel:BaseModel
    {

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayState { get; set; }

        /// <summary>
        /// 支付账号/子商号/Appid
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 支付机构（０ － 微信， 1 - 支付宝）
        /// </summary>
        public string Status { get; set; }
    }
}
