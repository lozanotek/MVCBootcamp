using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part2_Templates.Controllers
{
    using part2_Templates.Models;

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index() {
            var model = CreateModel();
            return View(model);
        }

        public ActionResult Create(Person newPerson)
        {
            return RedirectToAction("Index");
        }

        private Person CreateModel()
        {
            return new Person()
            {
                FirstName = "Test",
                LastName = "User",
                IsActive = true,
                HomeAddress = new Address()
                {
                    Line1 = "123 St.",
                    City = "Mayberry",
                    State = "Iowa",
                    Zip = "50309"
                }
            };
        }
    }
}
