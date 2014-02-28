using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ViewEnginePlus.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Register the new view engine and its routes
            RegisterViewEnginePlusRoutes();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private void RegisterViewEnginePlusRoutes()
        {
            // Clear all old ViewEngines and register our RazorThemeViewEngine
            System.Web.Mvc.ViewEngines.Engines.Clear();

            System.Web.Mvc.ViewEngines.Engines.Add(new RazorViewEnginePlus());

            ViewEnginePlus.AddViewRule("aaron", () =>
            {
                try
                {
                    return HttpContext.Current.Request.QueryString["testcase"] == "aaron" ? true : false;
                }
                catch (Exception e)
                {
                    return false;
                }
            });

            ViewEnginePlus.AddViewRule("dk", () =>
            {
                try
                {
                    return (string)HttpContext.Current.Session["language"] == "dk";
                }
                catch (Exception e)
                {
                    return false;
                }
            });
            ViewEnginePlus.AddViewRule("ie", () =>
            {
                try
                {
                    return (string)HttpContext.Current.Session["language"] == "ie";
                }
                catch (Exception e)
                {
                    return false;
                }
            });
            ViewEnginePlus.AddViewRule("nl", () =>
            {
                try
                {
                    return (string)HttpContext.Current.Session["language"] == "nl";
                }
                catch (Exception e)
                {
                    return false;
                }
            });
            ViewEnginePlus.AddViewRule("se", () =>
            {
                try
                {
                    return (string)HttpContext.Current.Session["language"] == "se";
                }
                catch (Exception e)
                {
                    return false;
                }
            });

            ViewEnginePlus.AddViewRule("debug", () =>
            {
                try
                {
                    return HttpContext.Current.Request.IsLocal || HttpContext.Current.Request.Url.Host.Contains("evdesign");
                }
                catch (Exception e)
                {
                    return false;
                }
            });

        }
    }
}