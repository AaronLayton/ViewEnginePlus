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

            ViewEnginePlus.AddViewRule("debug", () => {
                try
                {
                    var returnVal = false;

                    if (HttpContext.Current.Request.IsLocal) returnVal = true;

                    return returnVal;
                } catch(Exception e) {
                    return false;
                }
            });

            

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}