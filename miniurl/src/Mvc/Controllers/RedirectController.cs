namespace miniUrl.Mvc.Controllers {
    using System.Web.Mvc;
    using Services;

    [HandleError]
    public class RedirectController : BaseController {
        // Poor man's DI
        public RedirectController()
            : base(new UrlService()) {
        }

        public ActionResult UrlRedirect(string shortUrl) {
            if (!Service.IsValidUrlId(shortUrl)) {
                return RedirectToRoute("Default");
            }

            var url = Service.GetUrl(shortUrl);
            if (url == null) {
                return RedirectToRoute("Default");
            }

            Service.AddViewCount(shortUrl);
            return Redirect(url.Url);
        }
    }
}