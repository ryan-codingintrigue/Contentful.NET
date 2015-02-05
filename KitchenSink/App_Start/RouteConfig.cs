using System.Web.Mvc;
using System.Web.Routing;

namespace KitchenSink
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Dogs", action = "All", id = UrlParameter.Optional }
            );
        }
    }
}
