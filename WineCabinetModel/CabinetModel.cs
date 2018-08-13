using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace WineCabinetModel
{
    public class CabinetModel : ObjectBaseModel
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCODE { get; set; }

        /// <summary>
        /// 货柜账号
        /// </summary>
        public string ShelvesAccount { get; set; }

        /// <summary>
        /// 货柜密码
        /// </summary>
        public string AccountPasswd { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string LatitudeValue { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string LongitudeValue { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress { get; set; }

        /// <summary>
        /// 扫码用户
        /// </summary>
        public string ScavengingUser { get; set; }

        /// <summary>
        /// 1-酒柜、2-货架、3-其它
        /// </summary>
        public string ShelvesType { get; set; }

        /// <summary>
        /// 0-正常、1-RFID故障、2-锁故障、3-购买异常
        /// </summary>
        public string ShelvesState { get; set; }

        /// <summary>
        /// 交易单号、缺省为0
        /// </summary>
        public string DealNumber { get; set; }

        /// <summary>
        /// 20位商品码
        /// </summary>
        public string CommodityCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
    }
}
