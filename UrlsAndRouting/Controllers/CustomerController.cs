using System.Web.Mvc;

namespace UrlsAndRouting.Controllers
{
    [RouteArea("Services")]
    [RoutePrefix("Users")]
    public class CustomerController : Controller
    {
        [Route("~/Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";

            return View("ActionName");
        }

        [Route("Add/{user}/{id:int}")]
        public string Create(string user, int id)
        {
            return string.Format("User: {0}, ID: {1}", user, id);
        }


        [Route("Add/{user}/{password:alpha:length(6)}")]
        public string ChangePassword(string user, string password)
        {
            return string.Format("ChangePassword Method - User:{0}, Password:{1}", user, password);
        }


        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";

            return View("ActionName");
        }
    }
}