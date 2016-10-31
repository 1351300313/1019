using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppl1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult perpson()
        {
           
            return View();
        }


        public ActionResult List()
         {
             string[] data = new string[] {
                 "台风逼近广西景区关闭学校停课",
                "广西每年入境游客超300万" ,
                 "空军招飞初选10月24日开始",
                 "柳州城市轨道交通勘探工作已展开"};
 
             //ViewBag.data = data;
             //ViewData["data"] = data;
             ViewData.Model = data;
             return View();
         }
    public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}