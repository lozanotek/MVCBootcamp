namespace miniUrl.Mvc.Controllers {
    using System.Web.Mvc;
    using Services;

    [HandleError]
    public class HomeController : BaseController {
        public HomeController()
            : base(new UrlService()) {
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            return View();
        }
    }
}