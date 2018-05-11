using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace OperationPlatformModel
{
    public class BaseModel : ObjectBaseModel
    {

        /// <summary>
        /// 验证码
        /// </summary>
        public string Verification { get; set; }
    }
}
