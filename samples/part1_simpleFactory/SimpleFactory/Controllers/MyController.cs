namespace SimpleFactory.Controllers
{
    using System.Web.Mvc;

    public class MyController : FooController
    {
        public MyController(IMessageProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            ViewData["Message"] = ExecutionMessage;
            return View();
        }

        public ActionResult About()
        {
            var result = Index();
            return result;
        }
    }
}