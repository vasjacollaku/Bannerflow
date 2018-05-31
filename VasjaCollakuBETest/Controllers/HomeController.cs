using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VasjaCollakuBETest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banners()
        {
            ViewBag.Message = "Your contact page. Irrelevant but I wont remove them due to time limits.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. Irrelevant but I wont remove them due to time limits.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "The contact page of Vasja Collaku.";

            return View();
        }
    }
}