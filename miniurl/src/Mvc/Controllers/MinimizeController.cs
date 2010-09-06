namespace miniUrl.Mvc.Controllers {
    using System.Web.Mvc;
    using Services;

    public class MinimizeController : BaseController {
        public MinimizeController()
            : base(new UrlService()) {
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MinimizeUrl(string url) {
            if (string.IsNullOrEmpty(url)) {
                return RedirectToRoute("Default");
            }

            var miniUrl = Service.ContainsUrl(url) ?
                Service.GetByOriginalUrl(url) : Service.Minimize(url);

            return miniUrl == null ? RedirectToRoute("Default") :
                RedirectToRoute("showRoute", new { shortUrl = miniUrl.UrlHash });
        }
    }
}