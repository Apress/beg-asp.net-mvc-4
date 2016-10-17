using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace HaveYouSeenMe.Tests.Routes
{
    [TestClass]
    public class RoutesTest
    {
        RouteCollection routes;

        public RoutesTest()
        {
            // Create the routes table
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        }

        [TestMethod]
        public void IgnoreRoute_AXDResource_StopRoutingHandler()
        {
            // Arrange
            // Create the mock object for the HttpContextBase object
            Mock<HttpContextBase> mockContextBase = new Mock<HttpContextBase>();
            // Simulate the request for a resource of type {something}.axd
            mockContextBase.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath)
                           .Returns("~/Resource.axd");

            // Act
            // Get the route information based on the mock object
            RouteData routeData = routes.GetRouteData(mockContextBase.Object);

            // Assert
            // Make sure a route will process the resource
            Assert.IsNotNull(routeData);
            // Verify the type of route is of type StopRoutingHandler. This indicates
            // the request matches a URL pattern that won't use routing
            Assert.IsInstanceOfType(routeData.RouteHandler, typeof(StopRoutingHandler));
        }

        [TestMethod]
        public void DefaultRoute_HomePage_HomeControllerIndexActionOptionalId()
        {
            // Arrange
            // Create the mock object for the HttpContextBase object
            Mock<HttpContextBase> mockContextBase = new Mock<HttpContextBase>();
            // Simulate the request for the home page
            mockContextBase.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath)
                           .Returns("~/");

            // Act
            // Get the route information based on the mock object
            RouteData routeData = routes.GetRouteData(mockContextBase.Object);

            // Assert
            // Make sure a route will process the resource
            Assert.IsNotNull(routeData);
            // The controller is Home
            Assert.AreEqual("Home", routeData.Values["controller"]);
            // The action method is Index
            Assert.AreEqual("Index", routeData.Values["action"]);
            // The {id} segment is optional
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

    }
}
