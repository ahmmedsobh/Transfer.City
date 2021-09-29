using System.Web;
using System.Web.Optimization;

namespace Transfer.City
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/assets").Include(
                      "~/assets/plugins/global/plugins.bundle.js?v=7.2.8",
                      "~/assets/js/scripts.bundle.js?v=7.2.8",
                      "~/assets/js/custom/widgets.js",
                      "~/assets/js/custom/apps/chat/chat.js",
                      "~/assets/js/custom/modals/create-app.js",
                      "~/assets/js/custom/modals/upgrade-plan.js")
                );
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/plugins/global/plugins.bundle.css",
                      "~/assets/css/style.bundle.css",
                      "~/assets/plugins/custom/datatables/datatables.bundle.css",
                      "~/assets/css/tata.css"));
        }
    }
}
