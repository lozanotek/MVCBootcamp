namespace SimpleFactory.Controllers
{
    using System.Web.Mvc;

    public class MyControllerFactory : DefaultControllerFactory
    {
        private static readonly IMessageProvider defaultProvider = new DefaultMessageProvider();

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType == typeof(FooController))
            {
                return new MyController(defaultProvider);
            }

            var controller = base.GetControllerInstance(requestContext, controllerType);
            return controller;
        }

        protected override System.Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName.Contains("foo")) return typeof(FooController);

            var otherType = base.GetControllerType(requestContext, controllerName);
            return otherType;
        }
    }
}
