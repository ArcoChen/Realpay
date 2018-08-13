using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel
{
    public class AddressModel : BaseModel
    {
        /// <summary>
        /// 收件人名称
        /// </summary>
        public string AddressName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 地市
        /// </summary>
        public string RegionCity { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string CountyDistrict { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetaileAddress { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string Postalcode { get; set; }

        /// <summary>
        /// 地址ID
        /// </summary>
        public string AddressId { get; set; }
    }
}
