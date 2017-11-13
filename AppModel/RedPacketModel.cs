using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModel;

namespace AppModel
{
    public class RedPacketModel:BaseModel
    {
        ///// <summary>
        ///// 红包金额
        ///// </summary>
        //public decimal DistributeMoney { get; set; }

        /// <summary>
        /// 红包编号
        /// </summary>
        public string RedPacketNum { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeSteamp { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

    }
}
