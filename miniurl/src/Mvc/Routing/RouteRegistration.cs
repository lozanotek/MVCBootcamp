namespace miniUrl.Mvc.Routing {
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteRegistration {
        public RouteRegistration()
            : this(RouteTable.Routes) {
        }

        public RouteRegistration(RouteCollection routes) {
            Routes = routes;
        }

        public RouteCollection Routes { get; private set; }

        public void RegisterApplicationRoutes() {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute("redirectRoute",
                            "{shortUrl}",
                            new { controller = "Redirect", action = "UrlRedirect" },
                            new { shortUrl = @"\w{2,6}" });

            Routes.MapRoute("showRoute",
                            "{shortUrl}+",
                            new { controller = "show", action = "info" },
                            new { shortUrl = @"\w{2,6}" });

            Routes.MapRoute("minimizeRoute",
                            "miniurl",
                            new { controller = "Minimize", action = "MinimizeUrl" });

            Routes.MapRoute("Default",
                            "{controller}/{action}",
                            new { controller = "Home", action = "Index" });
        }
    }
}
