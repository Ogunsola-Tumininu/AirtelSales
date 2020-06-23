using System.Web;
using System.Web.Optimization;

namespace AirtelSales
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));

            RegisterLayout(bundles);
            RegisterIcons(bundles);
            RegisterShared(bundles);
            RegisterCharts(bundles);
        }

        private static void RegisterCharts(BundleCollection bundles)
        {
            //plugins | flot
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/jquery.flot").Include(
                "~/Omnistack-UI-html/lib/jquery.flot/jquery.flot.js"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/js/chart.flot.sampledata").Include(
                "~/Omnistack-UI-html/js/chart.flot.sampledata.js"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/jquery.flot.resize").Include(
                "~/Omnistack-UI-html/lib/jquery.flot/jquery.flot.resize.js"));

            //plugins | chart
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/chart.js").Include(
                            "~/Omnistack-UI-html/lib/chart.js/Chart.bundle.min.js"));

            //peity
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/peity").Include(
                "~/Omnistack-UI-html/lib/peity/jquery.peity.min.js"));
        }


        private static void RegisterShared(BundleCollection bundles)
        {
            //Shared Layout
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                "~/Scripts/Shared/_Layout.js"));

            //Simple bar
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/lib/simplebar/css").Include(
                                        "~/Omnistack-UI-html/lib/simplebar/css/simplebar.min.css"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/simplebar/js").Include(
                "~/Omnistack-UI-html/lib/simplebar/js/simplebar.min.js"));
        }

        private static void RegisterIcons(BundleCollection bundles)
        {
            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/lib/fontawesome-free/css").Include(
                                        "~/Omnistack-UI-html/lib/fontawesome-free/css/all.min.css"));

            // plugins | Ionicons
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/lib/ionicons/css").Include(
                                        "~/Omnistack-UI-html/lib/ionicons/css/ionicons.min.css"));

            // plugins | Typicons
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/lib/typicons.font").Include(
                                        "~/Omnistack-UI-html/lib/typicons.font/typicons.css"));
        }

        private static void RegisterLayout(BundleCollection bundles)
        {
            // azia
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/css").Include(
                "~/Omnistack-UI-html/css/azia.css"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/js").Include(
                "~/Omnistack-UI-html/js/azia.js"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/js/features").Include(
                "~/Omnistack-UI-html/js/features.js"));

            //Select 2
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/lib/select2/css").Include(
                "~/Omnistack-UI-html/lib/select2/css/select2.min.css"));

            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/select2/js").Include(
                "~/Omnistack-UI-html/lib/select2/js/select2.min.js"));

            // custom css
            bundles.Add(new StyleBundle("~/Omnistack-UI-html/css/custom").Include(
                "~/Omnistack-UI-html/css/custom.css"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/jquery").Include(
                                         "~/Omnistack-UI-html/lib/jquery/jquery.min.js"));

            //plugins | bootstrap
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/bootstrap/js").Include(
                                         "~/Omnistack-UI-html/lib/bootstrap/js/bootstrap.bundle.min.js"));

            //plugins | ionicons
            bundles.Add(new ScriptBundle("~/Omnistack-UI-html/lib/ionicons").Include(
                                         "~/Omnistack-UI-html/lib/ionicons/ionicons.js"));

            
        }


    }
}
