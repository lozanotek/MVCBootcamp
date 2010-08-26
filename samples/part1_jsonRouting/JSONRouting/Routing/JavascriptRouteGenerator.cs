#region License
//
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//
// Origianl source: http://github.com/enkari/ninject.website/blob/master/src/Ninject.Website.Framework/JavascriptRouteGenerator.cs
//
#endregion

namespace JSONRouting.Routing
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Routing;
    using Newtonsoft.Json.Linq;

    public class JavascriptRouteGenerator
    {
        private RouteCollection Routes { get; set; }

        public JavascriptRouteGenerator(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Write(string basePath, string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine("var _basePath = \"" + basePath + "\";");
                writer.WriteLine("var _routeTemplates = " + GetRouteTemplates(basePath) + ";");

                writer.Write(Properties.Resources.JsonRoutes);
            }
        }

        private JObject GetRouteTemplates(string basePath)
        {
            var templates = new JObject();

            var routableRoutes = GetRoutableRoutes();
            var groupByController = routableRoutes
                .Select(route => new RouteInfo(route))
                .GroupBy(info => info.Controller);

            foreach (var grouping in groupByController)
            {
                templates.Add(grouping.Key, new JObject(from route in grouping select new JProperty(route.Action, basePath + route.Url)));
            }

            return templates;
        }

        private IEnumerable<Route> GetRoutableRoutes()
        {
            foreach (RouteBase routeBase in Routes)
            {
                var route = routeBase as Route;

                if (route != null && route.Defaults != null)
                    yield return route;
            }
        }

        private class RouteInfo
        {
            public string Controller { get; private set; }
            public string Action { get; private set; }
            public string Url { get; private set; }

            public RouteInfo(Route route)
            {
                Controller = (string)route.Defaults["controller"];
                Action = (string)route.Defaults["action"];
                Url = route.Url;
            }
        }
    }
}