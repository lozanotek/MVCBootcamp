namespace JSONRouting.Routing
{
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static string Base(this HtmlHelper helper)
        {
            return Base(helper, true);
        }

        public static string Base(this HtmlHelper helper, bool injectJs)
        {
            var path = FullApplicationPath(helper.ViewContext.HttpContext.Request);

            var buffer = new StringBuilder();

            var builder = new TagBuilder("base");
            builder.Attributes.Add("href", path);

            buffer.AppendLine(builder.ToString());

            if (injectJs)
            {
                var scriptBuilder = new TagBuilder("script");
                scriptBuilder.Attributes.Add("type", "text/javascript");
                scriptBuilder.SetInnerText(string.Format("var baseUrl = '{0}'", path));

                buffer.AppendLine(scriptBuilder.ToString(TagRenderMode.Normal));
            }

            return buffer.ToString();
        }

        public static string FullApplicationPath(this Controller controller)
        {
            return FullApplicationPath(controller.Request);
        }

        public static string FullApplicationPath()
        {
            return FullApplicationPath(new HttpRequestWrapper(HttpContext.Current.Request));
        }

        public static string FullApplicationPath(this HtmlHelper helper)
        {
            return FullApplicationPath(helper.ViewContext.HttpContext.Request);
        }

        public static string FullApplicationPath(HttpRequestBase request)
        {
            var absolutePath = request.Url.AbsolutePath;
            if (absolutePath == "/")
            {
                return request.Url.AbsoluteUri;
            }

            var path = request.Url.AbsoluteUri.Replace(absolutePath, string.Empty);

            var queryIndex = path.IndexOf("?");
            if (queryIndex > 0)
            {
                path = path.Remove(queryIndex);
            }

            path = path + request.ApplicationPath;

            if (!path.EndsWith("/"))
            {
                path += "/";
            }

            return path;
        }

        public static string JsonRoutes(this HtmlHelper helper)
        {
            var context = helper.ViewContext.HttpContext;
            string basePath = FullApplicationPath(helper);
            string filename = context.Server.MapPath("~/scripts/routes.js");

            if (!File.Exists(filename))
            {
                JavascriptRouteGenerator jsGenerator = new JavascriptRouteGenerator(helper.RouteCollection);
                jsGenerator.Write(basePath, filename);
            }

            var builder = new TagBuilder("script");
            builder.Attributes.Add("type", "text/javascript");
            builder.Attributes.Add("src", "scripts/routes.js");

            return builder.ToString(TagRenderMode.Normal);
        }
    }
}