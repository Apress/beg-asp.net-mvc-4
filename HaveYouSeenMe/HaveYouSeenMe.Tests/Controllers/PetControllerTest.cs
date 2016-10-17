using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HaveYouSeenMe;
using HaveYouSeenMe.Controllers;
using System.Web.Mvc;
using HaveYouSeenMe.Models;
using System.Web.Routing;

namespace HaveYouSeenMe.Tests.Controllers
{
    [TestClass]
    public class PetControllerTests
    {
        private PetController _controller;

        public PetControllerTests()
        {
            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(x => x.GetPetByName(It.Is<string>(y => y == "Fido")))
                       .Returns(new Models.Pet { PetName = "Fido" });
            _controller = new PetController(_repository.Object);
        }

        private void SetControllerContext(string petName)
        {
            RouteData routeData = new RouteData();
            routeData.Values.Add("id", petName);
            ControllerContext context = new ControllerContext { RouteData = routeData, };
            _controller.ControllerContext = context;
        }


        [TestMethod]
        public void Index_NoInputs_ReturnsDefaultViewResult()
        {
            // Arrange
            PetController controller = new PetController();

            // Act
            ViewResult result = (ViewResult)controller.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void Display_ExistingPet_ReturnView()
        {
            // Arrange
            string petName = "Fido";
            SetControllerContext(petName);

            // Act
            ViewResult result = (ViewResult)_controller.Display();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(HaveYouSeenMe.Models.Pet));
            Assert.AreEqual(petName, ((Pet)result.Model).PetName);
        }

        [TestMethod]
        public void Display_NonExistingPet_ReturnNotFoundView()
        {
            // Arrange
            string petName = "Barney";
            SetControllerContext(petName);

            // Act
            var result = _controller.Display() as RedirectToRouteResult;

            // Assert
            // The action method returned an action result
            Assert.IsNotNull(result);
            // The redirection actually happened
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            // It was redirected to the NotFound action method
            Assert.AreEqual("NotFound", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Display_NonExistingPet_ReturnsHttp404()
        {
            // Arrange
            string petName = "Barney";
            SetControllerContext(petName);

            // Act
            var result = _controller.DisplayHttpNotFound() as HttpStatusCodeResult;

            // Assert
            // The action method returned an action result
            Assert.IsNotNull(result);
            // The action result is an HttpStatusCodeResult object
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            // The HTTP code is 404 (not found)
            Assert.AreEqual(404, result.StatusCode);
        }

        //[TestMethod]
        //public void PictureUpload_ValidFileSelected_ViewBagResultIsSuccess()
        //{
        //    // Arrange
        //    PetController controller = new PetController();
        //    PictureModel model = new PictureModel();

        //    // Act
        //    ViewResult result = (ViewResult)controller.PictureUpload(model);

        //    // Assert
        //    Assert.AreEqual("Success", result.ViewBag.UploadResult);
        //}
    }
}
