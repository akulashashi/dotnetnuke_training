using System;
using DotNetNuke.Web.Api;

namespace AuthServices
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("AuthServices", "default", "{controller}/{action}", new[] { "AuthServices" });

            mapRouteManager.MapHttpRoute("AuthServices", "Login", "{controller}/{action}/{Uid}/{Pwd}", new[] { "AuthServices" });
            
        }
    }
}