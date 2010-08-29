using System.Web.Mvc;

namespace quickLab.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            ActionResult result = View();

            var value = id % 2;

            switch (value)
            {
                case 0:
                    result = Json(id, JsonRequestBehavior.AllowGet);
                    break;

                case 1:
                    result = Redirect("http://www.google.com");
                    break;
            }

            return result;
        }
    }
}
