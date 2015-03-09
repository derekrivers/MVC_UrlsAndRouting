using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRouting.Tests
{
    [TestClass]
    public class RouteTests
    {


        [TestMethod]
        public void TestIncomingRoutes()
        {

            // Pass Tests

            //TestRouteMatch("~/Test", "Customer", "Index");
            //TestRouteMatch("~/Users/Add/Derek/12", "Customer", "Create");
            //TestRouteMatch("~/Users/Add/Derek/secret", "Customer", "ChangePassword");
            //TestRouteMatch("~/Users/List", "Customer", "List");


            //Fail Tests

            //TestRouteFail("~/Users/Add/Derek/secret1234");
          

            //TestRouteMatch("~/", "Home", "Index");

            //TestRouteMatch("~/Home", "Home", "Index");

            //TestRouteMatch("~/Home/Index", "Home", "Index");

            //TestRouteMatch("~/Home/About", "Home", "About");

            //TestRouteMatch("~/Home/About/MyId", "Home", "About", new{id = "MyId"});

            //TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About", new { id = "MyId", catchall = "More/Segments" });

            //TestRouteMatch("~/Customer", "Customer", "Index");

            //TestRouteMatch("~/Customer/List", "Customer", "List");

            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });

            //TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List", new { id = "All", catchall = "Delete" });

            //TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });

            // Fail Tests

            //TestRouteFail("~/Home/OtherAction");
            //TestRouteFail("~/Account/Index");
            //TestRouteFail("~/Account/About");


        }

        #region Test Helper Methods
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // create a mock request

            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();

            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();

            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create a mock context, using the request and response

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;

        }


        public void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act

            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //Assert 

            Assert.IsNotNull(result);
            //Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        //private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object routeProperties)
        //{
        //    Func<object, object, bool> valCompare = (v1, v2) =>
        //    {
        //        return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
        //    };

        //    bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

        //    if (routeProperties != null)
        //    {
        //        PropertyInfo[] propInfo = routeProperties.GetType().GetProperties();

        //        foreach (var pi in propInfo)
        //        {
        //            if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(routeProperties, null))))
        //            {
        //                result = false;
        //                break;
        //            }

        //        }
        //    }

        //    return result;
        //}

        private void TestRouteFail(string url)
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            //Assert
            Assert.IsTrue(result == null || result.Route == null);

        }


        #endregion

    }
}
