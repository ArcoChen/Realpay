using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace WineCabinetModel
{
    public class ShoppingCartModel : ObjectBaseModel
    {
        /// <summary>
        /// 商品码 7位 （单种商品标识）
        /// </summary>
        public string CommoditNumber { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string SupplyMoney { get; set; }

        /// <summary>
        /// 加减购物车 0 - 添加  1 - 减少
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 商家账号
        /// </summary>
        public string BUserAccount { get; set; }

        /// <summary>
        /// 酒柜账号
        /// </summary>
        public string ShelvesAccount { get; set; }

        /// <summary>
        /// 1-酒柜、2-货架、3-其它
        /// </summary>
        public string ShelvesType { get; set; }

        /// <summary>
        /// 商品码
        /// </summary>
        public string CommodityCode { get; set; }
    }
}
