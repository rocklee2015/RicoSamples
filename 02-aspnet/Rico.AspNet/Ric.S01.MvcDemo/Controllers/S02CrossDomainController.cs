using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ric.S01.MvcDemo.Controllers
{
    /// <summary>
    /// 跨域请求
    /// </summary>
    public class S02CrossDomainController : Controller
    {
        private static List<Hunter> Hunters = new List<Hunter>() {
             new Hunter(){  Name="KILLUA",Age=12},
             new Hunter(){ Name="GON",Age=12}
        };

        public S02CrossDomainController()
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //json 驼峰
                setting.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                return setting;
            });
        }

        // GET: S02CrossDomain
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HunterByGet()
        {
            var json = JsonConvert.SerializeObject(Hunters);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 方法一：
        /// </summary>
        /// <returns></returns>
        public ActionResult HunterAddHeadByCode()
        {

            // * 表示允许任何域名跨域访问
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            // 指定特定域名可以访问
            //Response.Headers.Add("Access-Control-Allow-Origin", "http:localhost:1080/");

            var json = JsonConvert.SerializeObject(Hunters);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 方法二：
        /// </summary>
        /// <returns></returns>
        public ActionResult HunterByJsonp()
        {
            var callback = Request.Params["callback"].ToString();
            Response.ContentType = "application/json;charset=utf-8";
            var json = JsonConvert.SerializeObject(Hunters);
            var result = callback + "(" + json + ")";
            //var result = callback +"(" + "{\"name\":\"KILLUA\",\"age\":12},{\"name\":\"GON\",\"age\":12}" + ")";

            //注：不能用json返回，会报错
            //return Json(result, JsonRequestBehavior.AllowGet);
            return Content(result);
        }

        [HttpPost]
        public ActionResult HunterByPost()
        {
            var json = JsonConvert.SerializeObject(Hunters);
            return Json(json);
        }
    }
    public class Hunter
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Date { get => DateTime.Now; }
    }
}