using System.Web.Mvc;

namespace part3_ModelMapping.Controllers
{
    using part3_ModelMapping.Models;

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var person = CreateModel();
            var viewModel = new PersonViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return View(viewModel);
        }

        private Person CreateModel()
        {
            return new Person { Id = 1, FirstName = "Test", LastName = "User" };
        }

    }
}
