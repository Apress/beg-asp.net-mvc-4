using HaveYouSeenMe.Models;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace HaveYouSeenMe.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Send()
        {
            var name = (string)RouteData.Values["id"];
            ViewBag.PetName = name;
            ViewBag.IsSent = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                //Send message
                //model.Message = Sanitizer.GetSafeHtmlFragment(model.Message);
                //ViewBag.IsSent = true;
                //return View(model);
                return RedirectToAction("ThankYou");
            }
            else
            {
                ViewBag.IsSent = false;
            }
            
            ModelState.AddModelError("", "One or more errors were found");
            return View(model);
        }

        public PartialViewResult ThankYou()
        {
            return PartialView();
        }

        public ActionResult GetPhoto()
        {
            var name = (string)RouteData.Values["id"];
            return RedirectToAction("GetPhoto", "Pet", new RouteValueDictionary { { "id", name } });
        }

        public ActionResult GetInfo()
        {
            var name = (string)RouteData.Values["id"];
            return RedirectToAction("GetInfo", "Pet", new RouteValueDictionary { { "id", name } });
        }

    }
}
