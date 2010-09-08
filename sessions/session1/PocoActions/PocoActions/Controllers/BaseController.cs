namespace PocoActions.Controllers {
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker() {
            return new PocoActionInvoker();
        }
    }
}