using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRouting.Infrastructure;

namespace UrlsAndRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute",myRoute);


            //routes.MapRoute("ShopSchema2", "Shop/OldAction", new {controller = "Home", action = "Index"});

            //routes.MapRoute("ShopSchema", "Shop/{action}", new {controller = "Home"});

            //routes.MapRoute("", "X{controller}/{action}");
            //routes.MapRoute("MyRoute", "{controller}/{action}", new{ controller = "Home", action = "Index"});
            //routes.MapRoute("", "Public/{controller}/{action}", new {controller = "Home", action = "Index"});

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", 
            //    new {controller = "Home", action = "Index", id = UrlParameter.Optional}, 
            //    new {controller = "^H.*", action = "^Index$|^About$", httpMethod = new HttpMethodConstraint("GET"), id= new RangeRouteConstraint(10,20)},
            //    new []{"UrlsAndRouting.AdditionalControllers"});

            routes.RouteExistingFiles = true;

            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("Content/{filename}.html");

            //routes.MapRoute("NewRoute", "App/Do{action}", new {controller = "Home"});

            routes.Add(new Route("SayHello", new CustomRouteHandler()));


            routes.Add(new LegacyRoute(new[]{
                                              "~/articles/windows.html",
                                              "~/old/.Net_1.0_Class_Library"}));

            routes.MapRoute("MyRoute", "{controller}/{action}", null, new []{"UrlsAndRouting.Controllers"});

            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" }, new[] { "UrlsAndRouting.Controllers" });




            //AreaRegistration.RegisterAllAreas();

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "UrlsAndRouting.Controllers" });
        }
    }
}
