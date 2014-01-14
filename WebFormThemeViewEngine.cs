using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ViewEnginePlus.ViewEngines
{
    public class WebFormThemeViewEngine : IViewEngine
    {
        private readonly WebFormViewEngine fallbackViewEngine = new WebFormViewEngine();
        private string lastTheme;
        private WebFormViewEngine lastEngine;
        private readonly object @lock = new object();

        // Temp
        private string activeTheme;

        // Implementations for IViewEngine

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return ThemeViewEngine().FindPartialView(controllerContext, partialViewName, useCache);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return ThemeViewEngine().FindView(controllerContext, viewName, masterName, useCache);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            ThemeViewEngine().ReleaseView(controllerContext, view);
        }

        private WebFormViewEngine ThemeViewEngine()
        {
            lock (@lock)
            {
                try
                {
                    // [todo] Determine where active theme is coming from
                    activeTheme = "Custom1";

                    // Allow the Theme to be overridden via the querystring ?theme=<newtheme>
                    // Will probably need securing with Request.IsAuthenticated || IsLocal?
                    var previewTheme = HttpContext.Current.Request.QueryString["theme"];
                    if (!string.IsNullOrEmpty(previewTheme))
                    {
                        activeTheme = previewTheme;
                    }

                    // Check if requested theme is the same as the last one and just return that
                    if (activeTheme == lastTheme)
                    {
                        return lastEngine;
                    }
                }
                catch (Exception)
                {
                    return fallbackViewEngine;
                }

                // If we have got this far then we are creating a new theme engine

                // Create a new base egnine
                lastEngine = new WebFormViewEngine();

                // New View locations
                // This leave all the default locations so /Views/{1}/{0}.cshtml will be used as a fall back aswell
                lastEngine.ViewLocationFormats =
                    new[]
                    {
                        "~/Themes/" + activeTheme + "/Views/{1}/{0}.aspx",
                        "~/Themes/" + activeTheme + "/Views/{1}/{0}.ascx",
                        "~/Themes/" + activeTheme + "/Views/{0}.aspx",
                        "~/Themes/" + activeTheme + "/Views/{0}.ascx"
                    }.Union(lastEngine.ViewLocationFormats).ToArray();

                // New Master locations
                lastEngine.MasterLocationFormats =
                    new[]
                    {
                        "~/Themes/" + activeTheme + "/Views/{1}/{0}.master",
                        "~/Themes/" + activeTheme + "/Views/Shared/{1}/{0}.master",
                        "~/Themes/" + activeTheme + "/Views/Shared/{0}.master",
                        "~/Themes/" + activeTheme + "/Views/{0}.master"
                    }.Union(lastEngine.MasterLocationFormats).ToArray();


                lastEngine.PartialViewLocationFormats = lastEngine.ViewLocationFormats;


                // Set the last used theme to the current active theme
                lastTheme = activeTheme;

                return lastEngine;
            }

        }
    }
}
