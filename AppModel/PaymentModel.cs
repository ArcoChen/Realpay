using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppModel
{
    public class PaymentModel : ProductInfoModel
    {
        /// <summary>
        /// 支付用户
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 收款方
        /// </summary>
        public string Payee { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public string TotalPrice { get; set; }

    }
}
