namespace miniUrl.Mvc.Controllers {
    using System.Web.Mvc;
    using Services;

    public abstract class BaseController : Controller {
        protected BaseController(IUrlService service) {
            Service = service;
        }

        public IUrlService Service { get; private set; }
    }
}