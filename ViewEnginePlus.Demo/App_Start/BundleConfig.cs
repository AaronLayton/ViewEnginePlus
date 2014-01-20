using System.Web;
using System.Web.Optimization;

namespace ViewEnginePlus.Demo
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                "~/js/bootstrap.js",
                "~/js/prettify.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                "~/css/bootstrap.css",
                "~/css/bootstrap-theme.css",
                "~/css/prettify.css"));

        }
    }
}