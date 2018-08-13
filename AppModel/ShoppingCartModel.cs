using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel
{
    public class ShoppingCartModel : BaseModel
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public string DealSum { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public string DealMoney { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        public string SupplyMoney { get; set; }

        /// <summary>
        /// 收件人名
        /// </summary>
        public string AddresseeName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string RegionCity { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string CountyDistrict { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailedAddress { get; set; }

        /// <summary>
        /// 订单类型 0-网上商城、1-智能超市
        /// </summary>
        public string DealType { get; set; }

        /// <summary>
        /// 商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 货架账号
        /// </summary>
        public string ScavengingUser { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string CommodityNumber { get; set; }
    }
}
