﻿using System;
using DotNetNuke.Web.Api;

namespace MyServices
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("MyServices", "default", "{controller}/{action}", new[] { "MyServices" });

            mapRouteManager.MapHttpRoute("MyServices", "HelloName", "{controller}/{action}/{Id}", new[] { "MyServices" });
            mapRouteManager.MapHttpRoute("MyServices", "HelloName2", "{controller}/{action}/{Uid}/{Pwd}", new[] { "MyServices" });
            mapRouteManager.MapHttpRoute("MyServices", "HelloName3", "{controller}/{action}/{Id}/{Id2}/{Id3}", new[] { "MyServices" });

            mapRouteManager.MapHttpRoute("MyServices", "HelloFullNameWrong", "{controller}/{action}/{Firstname}/{Lastname}", new[] { "MyServices" });

            mapRouteManager.MapHttpRoute("MyServices", "HelloFullName", "{controller}/{action}/{Firstname}/{Lastname}/{Middlename}", new[] { "MyServices" });


            mapRouteManager.MapHttpRoute("MyServices", "Login", "{controller}/{action}/{Id}/{Id2}", new[] { "MyServices" });
        }
    }
}