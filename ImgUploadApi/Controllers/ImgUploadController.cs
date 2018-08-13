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
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Web;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace ImgUploadApi.Controllers
{
    public class ImgUploadController : ApiController
    {
        #region 配置参数
        private static readonly long MEMORY_SIZE = 5 * 1024 * 1024;
        private static readonly string ROOT_PATH = @"C:\imgData\";
        private static JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

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

        [HttpPost]
        public HttpResponseMessage Post()
        {
            string code = string.Empty;
            string msg = string.Empty;
            string FilePath = @"C:\imgData\";
            List<string> list = new List<string>();

            #region MyRegion
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                if (files != null && files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];

                        string filename = file.FileName;
                        string fileType = filename.Substring(filename.LastIndexOf(".") + 1, (filename.Length - filename.LastIndexOf(".") - 1));
                        string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        ///判断文件夹是否存在
                        if (Directory.Exists(FilePath) == false)
                        {
                            Directory.CreateDirectory(FilePath);
                        }
                        try
                        {
                            string imgpath = FilePath + FileName + "." + fileType;
                            file.SaveAs(imgpath);
                            list.Add(FileName + "." + fileType);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error(ex.ToString());
                        }
                    }
                    code = "1";
                    msg = "图片上传成功";

                }
            }
            catch (Exception)
            {
                code = "0";
                msg = "图片上传失败";
            }


            JObject json = new JObject();
            json = ReturnCode(code, msg, list);
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(json.ToString(), Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
            #endregion
        }

        /// <summary>
        /// 图片上传 2-图片超过5M 0-图片上传失败
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ImgPost()
        {

            string code = "2";
            string msg = string.Empty;
            List<string> resources = new List<string>();
            // multipart/form-data  
            // 采用MultipartMemoryStreamProvider  
            var provider = new MultipartMemoryStreamProvider();

            Dictionary<string, string> dic = new Dictionary<string, string>();

            //读取文件数据  
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var item in provider.Contents)
            {
                /// 判断是否是文件  
                if (item.Headers.ContentDisposition.FileName != null)
                {
                    ///判断文件大小不超过5M
                    if (item.Headers.ContentLength < MEMORY_SIZE)
                    {
                        ///获取到流  
                        var ms = item.ReadAsStreamAsync().Result;
                        //进行流操作  
                        using (var br = new BinaryReader(ms))
                        {
                            if (ms.Length <= 0)
                                break;
                            ///读取文件内容到内存中  
                            var data = br.ReadBytes((int)ms.Length);

                            //Info  
                            FileInfo info = new FileInfo(item.Headers.ContentDisposition.FileName.Replace("\"", ""));
                            ///文件类型  
                            string fileType = info.Extension.Substring(1).ToLower();

                            ///当前时间作为ID  
                            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileType;

                            ///Write  
                            try
                            {
                                ///文件存储地址  
                                string Fpath = DateTime.Today.ToString("yyyyMMdd");
                                string dirPath = Path.Combine(ROOT_PATH, Fpath);
                                if (!Directory.Exists(dirPath))
                                {
                                    Directory.CreateDirectory(dirPath);
                                }

                                File.WriteAllBytes(Path.Combine(dirPath, fileName), data);
                                resources.Add(Fpath + "/" + fileName);

                                code = "1";
                                msg = "上传成功";
                            }
                            catch (Exception ex)
                            {
                                code = "0";
                                msg = "文件上传失败，请稍后重试";
                                LogHelper.LogError(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        code = "2";
                        msg = "文件大于5M，请重新选择";
                        break;
                    }
                }
                else
                {
                    string val = await item.ReadAsStringAsync();
                    dic.Add(item.Headers.ContentDisposition.Name, val);
                }
            }


            ///返回
            JObject json = new JObject();
            json = ReturnCode(code, msg, resources);
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(json.ToString(), Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;

        }

        /// <summary>
        /// 移动商品图片到指定文件夹
        /// </summary>
        /// <param name="imgString">缓存图片地址</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgPath">图片存放地址</param>
        [HttpPost]
        public HttpResponseMessage MoveImg(ImgModel model)
        {
            string Result = string.Empty;
            try
            {
                ///缓存图片地址
                string OldPath = string.Empty;

                ///新地址文件夹
                string FilePath = string.Empty;

                ///图片新地址
                string NewPath = string.Empty;

                OldPath = ROOT_PATH + model.SourceFileName;
                string ImgType = System.IO.Path.GetExtension(OldPath);
                FilePath = model.ImgDisk + ":/" + model.ImgRoot + "/" + model.UserAccount + "/" + model.ImgAttribute + "/";


                if (!model.SourceFileName.Contains(model.UserAccount))
                {
                    ///判断文件夹是否存在
                    if (Directory.Exists(FilePath) == false)
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    NewPath = FilePath + model.ImgName + ImgType;

                    if (File.Exists(NewPath))
                    {
                        File.Delete(NewPath);

                        ///移动文件
                        File.Copy(OldPath, NewPath);
                    }
                    else
                    {
                        ///移动文件
                        File.Copy(OldPath, NewPath);
                    }
                    Result = model.ImgIp + model.UserAccount + "/" + model.ImgAttribute + "/" + model.ImgName + ImgType;
                }
                else
                {
                    Result = model.SourceFileName;
                }
            }
            catch (Exception ex)
            {
                Result = "2";
                LogHelper.Error(ex.ToString());
            }


            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("utf-8")) };

            return Respend;
        }

        /// <summary>
        /// MoveImg
        /// </summary>
        /// <param name="imgString">缓存图片地址</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgPath">图片存放地址</param>
        [HttpPost]
        public HttpResponseMessage MoveImges(ImgModel model)
        {
            ///图片Key
            string Key = string.Empty;

            ///图片Value
            string Value = string.Empty;

            ///缓存图片地址
            string OldPath = string.Empty;

            ///新地址文件夹
            string FilePath = string.Empty;

            ///图片新地址
            string NewPath = string.Empty;

            ///图片类型
            string ImgType = string.Empty;

            string ImgSort = string.Empty;

            #region 多张一起修改
            JObject jsons = (JObject)JsonConvert.DeserializeObject(model.SourceFileName);

            List<string> list = new List<string>();
            foreach (var i in jsons)
            {
                Key = i.Key.ToString();
                Value = i.Value.ToString();
                if (!Value.Contains(model.UserAccount))
                {
                    OldPath = ROOT_PATH + Value;
                    ImgType = System.IO.Path.GetExtension(Value);
                    FilePath = model.ImgDisk + ":/" + model.ImgRoot + "/" + model.UserAccount + "/" + model.ImgAttribute + "/";

                    ///判断文件夹是否存在
                    if (Directory.Exists(FilePath) == false)
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    string[] path = Directory.GetFiles(FilePath).OrderBy(x => x.Length).ThenBy(x => x).ToArray();

                    if (path.Length == 0)
                    {
                        ImgSort = 0.ToString("d2");
                    }
                    else
                    {
                        int Before = path[path.Length - 1].LastIndexOf("/");
                        int After = path[path.Length - 1].LastIndexOf(".");
                        ImgSort = (int.Parse(path[path.Length - 1].Substring(Before + 1, After - Before - 1)) + 1).ToString("d2");
                    }

                    NewPath = FilePath + model.ImgName + ImgSort + ImgType;

                    if (File.Exists(NewPath))
                    {
                        File.Delete(NewPath);

                        ///移动文件
                        File.Copy(OldPath, NewPath);
                    }
                    else
                    {
                        ///移动文件
                        File.Copy(OldPath, NewPath);
                    }

                    //NewPath = model.ImgIp + model.UserAccount + "/" + model.ImgAttribute + "/" + ImgSort + ImgType;
                }
                else
                {
                    NewPath = Value;
                }

                list.Add(model.ImgName + ImgSort + ImgType);
            }
            //string ImgRootPath = model.ImgIp + model.UserAccount + "/" + model.ImgAttribute + "/,";
            string ServerPath = string.Join(",", list.ToArray());

            string Result = ServerPath;
            #endregion

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("utf-8")) };

            return Respend;
        }

        /// <summary>
        /// 移动商品图片到指定文件夹
        /// </summary>
        /// <param name="imgString">缓存图片地址</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgPath">图片存放地址</param>
        [HttpPost]
        public HttpResponseMessage MoveCommodityImg(ImgModel model)
        {
            string Result = string.Empty;
            try
            {
                ///缓存图片地址
                string OldPath = string.Empty;

                ///新地址文件夹
                string FilePath = string.Empty;

                ///图片新地址
                string NewPath = string.Empty;

                ///图片类型
                string ImgType = string.Empty;

                ///图片排序
                string imgSort = string.Empty;


                OldPath = ROOT_PATH + model.SourceFileName;
                ImgType = System.IO.Path.GetExtension(OldPath);
                FilePath = model.ImgDisk + ":/" + model.ImgRoot + "/" + model.UserAccount + "/" + model.ImgAttribute + "/";

                ///判断文件夹是否存在
                if (Directory.Exists(FilePath) == false)
                {
                    Directory.CreateDirectory(FilePath);
                }

                //NewPath = FilePath + model.ImgName + ImgType;
                NewPath = FilePath + model.ImgName;

                if (File.Exists(NewPath))
                {
                    File.Delete(NewPath);

                    ///移动文件
                    File.Copy(OldPath, NewPath);
                    Result = "1";
                }
                else
                {
                    ///移动文件
                    File.Copy(OldPath, NewPath);
                    Result = "1";
                }
            }
            catch (Exception ex)
            {
                Result = "2";
                LogHelper.Error(ex.ToString());
            }


            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("utf-8")) };

            return Respend;
        }

        /// <summary>
        /// 删除指定商品图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteCommodityImg(ImgModel model)
        {
            string Result = string.Empty;
            ///图片保存位置
            string FilePath = model.ImgDisk + "://" + model.ImgRoot + "/" + model.UserAccount + "/" + model.ImgAttribute + "/" + model.SourceFileName;

            //JArray jArray = new JArray();
            //List<int> list = new List<int>();
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Result = "1";
            }
            else
            {
                Result = "2";
            }
            //Result = ReturnCode(jArray).ToString();
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("utf-8")) };

            return Respend;
        }

        public static JObject ReturnCode(string code, string msg, List<string> list)
        {
            JArray jArray = new JArray();
            for (int i = 0; i < list.Count(); i++)
            {
                jArray.Add(list[i]);
            }

            JObject json = new JObject();
            json.Add("code", code);
            json.Add("msg", msg);
            json.Add("RETURNCODE", "200");
            json.Add("SOURCE", "imgUpload");
            json.Add("CREDENTIALS", "0");
            json.Add("INDEX", DateTime.Now.ToString("yyyyMMddmmss"));
            json.Add("DATA", jArray);
            return json;
        }

        public static JObject ReturnCode(JArray jArray)
        {

            JObject json = new JObject();
            json.Add("RETURNCODE", "200");
            json.Add("SOURCE", "DeleteCommodity");
            json.Add("CREDENTIALS", "0");
            json.Add("INDEX", DateTime.Now.ToString("yyyyMMddmmss"));
            json.Add("DATA", jArray);
            return json;
        }
    }

}
