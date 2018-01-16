using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class UserPermissionModel : BaseModel
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        ///  子项名称
        /// </summary>
        public string SubitemName { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 浏览（0-允许、1-不允许）
        /// </summary>
        public string TourOperation { get; set; }

        /// <summary>
        /// 编辑（0-允许、1-不允许）
        /// </summary>
        public string EditOperation { get; set; }

        /// <summary>
        /// 删除（0-允许、1-不允许）
        /// </summary>
        public string DeleteOperation { get; set; }

        public string DATA1 { get; set; }
    }
}
