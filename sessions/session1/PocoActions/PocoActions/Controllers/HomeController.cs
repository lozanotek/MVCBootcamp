using System.Web.Mvc;

namespace PocoActions.Controllers
{
    using PocoActions.Models;

    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult OldWay() {
            var model = CreateModel();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public Person NewWay() {
            return CreateModel();
        }

        private Person CreateModel()
        {
            return new Person { FirstName = "Joe", LastName = "User" };
        }
    }
}
