using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowError()
        {
            ViewData["ErrorCode"] = 12345;
            ViewData["ErrorDescription"] = "Something bad happened";
            ViewData["ErrorDate"] = DateTime.Now;
            ViewData["Exception"] = new Exception();

            return View();
        }

        public ActionResult ShowError2()
        {
            ViewBag.ErrorCode = 12345;
            ViewBag.ErrorDescription = "Something bad happened";
            ViewBag.ErrorDate = DateTime.Now;
            ViewBag.Exception = new Exception();

            return View();
        }


    }
}
