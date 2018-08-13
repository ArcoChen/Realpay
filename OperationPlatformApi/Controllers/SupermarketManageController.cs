using OperationPlatformModel;
using ReCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace OperationPlatformApi.Controllers
{
    public class SuperMarketManageController : ApiController
    {
        #region 配置参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("operation", username);
        #endregion

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/ShowShelfInfo  货架管理首页
            * @apiDescription 货架管理首页
            * @apiName ShowShelfInfo
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   ShowShelfInfo
            * @apiParam {string} ActivationState 货架状态 0-未激活（默认）1-已激活
            * @apiSuccess {Array} DATA {UserAccount:用户账号,ShelvesAccount:货架账号,ShelvesType:货架类型,ActivationState:货架状态,DialMobile:拨号电话,WorkAddress:工作地址,MACAddress:MAC地址,LongitudeValue:经度,LatitudeValue:纬度,LoginNum:登录次数,LoginTime:登录时间,LoginIP:登录IP,LoginLastTime:上一次登录时间,LoginLastIP:上一次登录IP}
            */
        #endregion
        /// <summary>
        /// 货架管理首页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ShowShelfInfo(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.ActivationState = ParametersFilter.FilterSqlHtml(model.ActivationState, 1);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }


        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/ViewProduct  查看货架商品
            * @apiDescription 查看货架商品
            * @apiName ViewProduct
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   ViewProduct
            * @apiParam {string} ShelvesAccount 货架账号
            * @apiSuccess {Array} DATA {CommodityNumber:七位商品码,BarCode:条形码,StockSum:库存}
            */
        #endregion
        /// <summary>
        /// 查看商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAdvertisementApply(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.ShelvesAccount = ParametersFilter.FilterSqlHtml(model.ShelvesAccount, 64);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/ChangeStatus  修改货架的状态
            * @apiDescription 查看货架商品
            * @apiName ChangeStatus
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   ChangeStatus
            * @apiParam {string} ShelvesAccount 货架账号
            * @apiParam {string} ActivationState 货架状态 0-未激活 1-已激活
            * @apiSuccess {Array} DATA 0-失败 1-成功
            */
        #endregion
        /// <summary>
        /// 修改货架的状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeStatus(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.ShelvesAccount = ParametersFilter.FilterSqlHtml(model.ShelvesAccount, 64);
                model.ActivationState = ParametersFilter.FilterSqlHtml(model.ActivationState, 1);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/DisplayOrderInfo  获取订单列表
            * @apiDescription 获取订单列表
            * @apiName DisplayOrderInfo
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   DisplayOrderInfo
            * @apiParam {string} DealStatus 订单状态(1-未支付 5-已确认)
            * @apiSuccess {Array} DATA {DealNumber:交易单号,ShelvesAccount:货架账号,CommodityName:商品名称,DealSum:商品数量,Univalent:单价,DealMoney:订单金额,UserAccount:下单用户,PaymentTime:下单时间,PayInstitution:支付方式,TradeTime:完成时间}
            */
        #endregion
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DisplayOrderInfo(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DealStatus = ParametersFilter.FilterSqlHtml(model.DealStatus, 1);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/OrderDetails  订单详情
            * @apiDescription 获取单个订单的详情
            * @apiName OrderDetails
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   OrderDetails
            * @apiParam {string} DealNumber 订单号
            * @apiSuccess {Array} DATA {ShelvesAccount:货架账号,,DealSum:商品数量,Univalent:单价,DealMoney:订单金额,DealStatus:订单状态（0-购物车、1-未支付、2-未发货、3-已发货、4-已收货、5-已确认、6-退货）,ReceiptTime:确认时间,DeliveryTime:发货时间,ConfirmTime:完成时间,CommodityName:商品名称,WorkAddress:货架地址}
            */
        #endregion
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage OrderDetails(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DealNumber = ParametersFilter.FilterSqlHtml(model.DealNumber, 32);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/WaiterList  服务员列表
            * @apiDescription 服务员列表
            * @apiName WaiterList
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   WaiterList
            * @apiParam {Array} DATA 传默认值0
            * @apiSuccess {Array} DATA {UserAccount:用户账号,UserMobile:用户电话,UserAvatar:用户头像,RegisterTime:注册时间}
            */
        #endregion
        /// <summary>
        /// 服务员列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage WaiterList(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/ChangeWaiterStatus  更改服务员状态
            * @apiDescription 更改服务员状态
            * @apiName ChangeWaiterStatus
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   ChangeWaiterStatus
            * @apiParam {string} UserAccount 用户账号
            * @apiParam {string} UserType 用户类型（5-会员 6-服务员） 
            * @apiSuccess {Array} DATA {0-失败 1-成功}
            */
        #endregion
        /// <summary>
        /// 更改服务员状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeWaiterStatus(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);
                model.UserType = ParametersFilter.FilterSqlHtml(model.UserType, 1);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region aipdoc注释
        /**
            * @api {Post} api/SuperMarketManage/AddNewWaiter  新增服务员
            * @apiDescription 新增服务员
            * @apiName AddNewWaiter
            * @apiGroup SupermarketManage
            * @apiVersion 1.0.0
            * @apiParam {String} SOURCE    文件名
            * @apiParam {String} CREDENTIALS   用户名或凭证，无凭证缺省填0
            * @apiParam {String} TERMINAL   用户访问终端 0-PC，1-Android，2-iOS
            * @apiParam {String} INDEX   数据包序列，缺省填写时间格式年月日时分秒：20160101123001
            * @apiParam {String} METHOD   AddNewWaiter
            * @apiParam {string} UserMobile or UserAccount  手机号 或 用户账号
            * @apiParam {string} Type 1-手机号 2-用户账号
            * @apiSuccess {Array} DATA {UserAccount:用户账号,UserMoible:用户手机号,UserAvatar:用户头像,RegisterTime:注册时间}
            */
        #endregion
        /// <summary>
        /// 新增服务员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddNewWaiter(SuperMarketModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
              
                model.Type = ParametersFilter.FilterSqlHtml(model.Type, 1);
                if(model.Type=="1")
                {
                    model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                }
                else if(model.Type=="2")
                {
                    model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);
                }
                
                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
    }
}
