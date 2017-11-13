using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AppModel
{
    public class ProductInfoModel:BaseModel
    {

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string CommodityImg { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string SupplyMoney { get; set; }

        /// <summary>
        /// 销售店地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProductionDate { get; set; }

        /// <summary>
        /// 生产地址
        /// </summary>
        public string ProductionAddress { get; set; }

        /// <summary>
        /// 举报信息
        /// </summary>
        public string ReportInfo { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        public string CommodityProfile { get; set; }

        public string Screenshot { get; set; }
    }
}
