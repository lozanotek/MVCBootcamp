namespace miniUrl.Web {
    using System.Web;
    using Mvc.Routing;

    public class MvcApplication : HttpApplication {
        public static RouteRegistration appRegistration = new RouteRegistration();

        protected void Application_Start() {
            appRegistration.RegisterApplicationRoutes();
        }
    }
}