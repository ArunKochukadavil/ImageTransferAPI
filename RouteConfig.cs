using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JsonResponseTestWebAPI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Json",
				url: "{controller}/{action}/{id}/{val1}/{val2}",
				defaults: new { controller = "Home", action = "JsonResponse", val1="1", val2="2",ApplicationId=UrlParameter.Optional }
				);
			
		}
	}
}
