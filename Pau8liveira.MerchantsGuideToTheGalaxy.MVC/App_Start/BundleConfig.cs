using System.Web;
using System.Web.Optimization;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.1.11.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/YTPlayer").Include(
                        "~/Scripts/YTPlayer.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/fileinput").Include(                     
                      "~/Scripts/fileinput/fileinput.js",
                      "~/Scripts/fileinput/config.js"));

            bundles.Add(new StyleBundle("~/Content/css/style").Include(
                "~/Content/css/style.css",
                "~/Content/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/fileinput").Include(
                        "~/Content/css/fileinput.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}