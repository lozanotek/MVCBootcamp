namespace SimpleFactory.Controllers
{
    using System.Web.Mvc;

    public class FooController : Controller
    {
        public FooController(IMessageProvider provider)
        {
            Provider = provider;
        }

        private IMessageProvider Provider { get; set; }

        public string ExecutionMessage
        {
            get { return "I'm a FooController and " + Provider.GetMessage(); }
        }
    }
}