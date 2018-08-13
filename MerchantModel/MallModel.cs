using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantModel
{
    public class MallModel:BaseModel
    {

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 7位商品码(商品数量)
        /// </summary>
        public string CommodityNumber { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 生产商家
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 生产标准号
        /// </summary>
        public string StandardNumber { get; set; }

        /// <summary>
        /// 生产地址
        /// </summary>
        public string ProductionAddress { get; set; }

        /// <summary>
        /// 生产许可证
        /// </summary>
        public string ProductionLicense { get; set; }

        /// <summary>
        /// 主要成分
        /// </summary>
        public string CommodityProfile { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public string StockSum { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string SupplyMoney { get; set; }

        /// <summary>
        /// 上架状态
        /// </summary>
        public string MallState { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        ///7位商品码 
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 订单总价
        /// </summary>
        public string DealMoney { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayInstitution { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string AddressName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        
        /// <summary>
        /// 收货地址
        /// </summary>
        public string DetailedAddress { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string OddNumbers { get; set; }

        /// <summary>
        /// 物流单位
        /// </summary>
        public string CarrierId { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postalcode { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 收货时间
        /// </summary>
        public string ReceiptTime { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public string ConfirmTime { get; set; }

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string TradeTime { get; set; }

        /// <summary>
        /// 接口状态
        /// </summary>
        public string OPStatus { get; set; }

        /// <summary>
        /// 商家用户账号
        /// </summary>
        public string MUserAccount { get; set; }

        /// <summary>
        /// 活动状态 0-未审核、1-已通过、2-未通过	
        /// </summary>
        public string AuditingState { get; set; }

        public string State { get; set; }

        public string ID { get; set; }
    }
}
