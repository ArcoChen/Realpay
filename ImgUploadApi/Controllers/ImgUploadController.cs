using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ReCommon;
using ImageModel;
using Newtonsoft.Json;

namespace ImgUploadApi.Controllers
{
    public class ImgUploadController : ApiController
    {
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="model">图片实体类</param>
        /// <returns></returns>
        [HttpPost]
        public string Upload(ImgModel model)
        {
            string Result = string.Empty;
            try
            {
                Result = CharConversion.SaveImg(model.ImgIp, model.ImgDisk, model.ImgRoot, model.UserAccount, model.ImgAttribute, model.ImgUpLoadDate, model.ImgName, model.ImgString);

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            return Result;
        }
    }
}
