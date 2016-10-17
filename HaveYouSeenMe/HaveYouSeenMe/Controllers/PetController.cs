using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveYouSeenMe.Models;
using System.IO;
using HaveYouSeenMe.Models.Business;

namespace HaveYouSeenMe.Controllers
{
    public class PetController : Controller
    {
        private IRepository _repository;

        public PetController()
        {
            _repository = new EFRepository();
        }

        public PetController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Pet/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PictureUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if (model.PictureFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                var pm = new PetManagement();
                pm.CreateThumbnail(fileName, filePath, 100, 100, true);

                ViewBag.UploadResult = "Success";
            }

            return View(model);
        }

        public ActionResult Display()
        {
            var name = (string)RouteData.Values["id"];
            var pm = new PetManagement(_repository);
            var model = pm.GetByName(name);

            if (model == null)
                return RedirectToAction("NotFound");

            return View(model);
        }

        public ActionResult DisplayHttpNotFound()
        {
            var name = (string)RouteData.Values["id"];
            var pm = new PetManagement(_repository);
            var model = pm.GetByName(name);

            if (model == null)
                return HttpNotFound("Pet Not Found...");

            return View(model);
        }

        //public ActionResult Display(string name)
        //{
        //    var pm = new PetManagement();
        //    var model = pm.GetByName(name);

        //    if (model == null)
        //        return RedirectToAction("NotFound");

        //    return View(model);
        //}

        public JsonResult GetInfo()
        {
            var name = (string)RouteData.Values["id"];
            var pm = new PetManagement();
            var pet = pm.GetByName(name);

            return Json(pet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPhoto()
        {
            var name = (string)RouteData.Values["id"];
            ViewBag.Photo = string.Format("/Content/Uploads/{0}.jpg", name);

            return PartialView();
        }

        public ActionResult NotFound()
        {
            return View();
        }







        public FileResult DownloadPetPicture()
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType, fileName);
        }

        public HttpStatusCodeResult CustomError()
        {
            return new HttpStatusCodeResult(410, "My Custom Error");
        }

        public HttpStatusCodeResult UnauthorizedError()
        {
            return new HttpUnauthorizedResult("Custom Unauthorized Error");
        }

        public ActionResult NotFoundError()
        {
            return HttpNotFound("Nothing here...");
        }

    }
}
