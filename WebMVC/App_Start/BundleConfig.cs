using System.Web;
using System.Web.Optimization;

namespace WebMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js").Include(
                        "~/Scripts/bootstrap-notify.js").Include(
                        "~/Scripts/bootstrap-select.js").Include(
                        "~/Scripts/demo.js").Include(
                        "~/Scripts/chartist.min.js").Include(
                        "~/Scripts/light-bootstrap-dashboard.js").Include(
                        "~/Scripts/bootstrap-table.js").Include(
                        "~/Scripts/gsdk-switch.js").Include(
                        "~/Scripts/jquery.sharrre.js")

                        );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/animate.min.css",
                      //"~/Content/demo.css",
                       "~/Content/pe-icon-7-stroke.css",

                      "~/Content/light-bootstrap-dashboard.css",
                       "~/Content/fresh-bootstrap-table.css"
                      ));

        }
    }
}
