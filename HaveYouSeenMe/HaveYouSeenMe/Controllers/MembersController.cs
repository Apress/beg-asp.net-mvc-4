using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        //
        // GET: /Members/

        public ActionResult Index()
        {
            return View();
        }

    }
}
