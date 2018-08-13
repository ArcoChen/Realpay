using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationPlatformModel
{
    public class SuperMarketModel : BaseModel
    {
        /// <summary>
        /// 货架状态 
        /// </summary>
        public string ActivationState { get; set; }

        /// <summary>
        /// 货架账号
        /// </summary>
        public string ShelvesAccount { get; set; }

        /// <summary>
        /// 订单状态（0-购物车、1-未支付、2-未发货、3-已发货、4-已收货、5-已确认、6-退货）
        /// </summary>
        public string DealStatus { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 参数类型（1-手机号 2-用户账号）
        /// </summary>
        public string Type { get; set; }
    }
}
