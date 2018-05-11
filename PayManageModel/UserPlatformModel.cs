using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayManageMentModel
{
    public class UserPlatformModel:BaseModel
    {

        public string UserPasswd { get; set; }

        public string UserState { get; set; }

        public string UserType { get; set; }

        public string UserName { get; set; }

        public string RegisterTime { get; set; }

        public string LoginNum { get; set; }

        public string LoginTime { get; set; }

        public string LoginIP { get; set; }

        public string LoginLastTime { get; set; }

        public string LoginLastIP { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string PageNum { get; set; }
    }
}
