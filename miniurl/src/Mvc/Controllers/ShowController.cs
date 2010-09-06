namespace miniUrl.Mvc.Controllers {
    using System.Web.Mvc;
    using Services;

    public class ShowController : BaseController {
        public ShowController()
            : this(new UrlService()) {
        }

        public ShowController(IUrlService service)
            : base(service) {
        }

        public ActionResult Info(string shortUrl) {
            if (!Service.IsValidUrlId(shortUrl)) {
                return RedirectToRoute("Default");
            }

            var url = Service.GetUrl(shortUrl);
            return url == null ? (ActionResult)RedirectToRoute("Default") : View(url);
        }
    }
}
