using System.Web;
using System.Web.Optimization;

namespace Logger
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //            Script bundles
            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/app/logger-site").Include(
                "~/Scripts/app/logger-site*"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-datepicker").Include(
                "~/Scripts/bootstrap-datepicker*"));

            bundles.Add(new ScriptBundle("~/Scripts/validation").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/Prettify/run_prettify").Include(
                "~/Scripts/Prettify/run_prettify.js",
                "~/Scripts/Prettify/prettify.js"));

            bundles.Add(new ScriptBundle("~/Scripts/cookie").Include(
                "~/Scripts/cookie*"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.history").Include(
                "~/Scripts/jquery.history*"));


            //            Style bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css-admin").Include(
                "~/Areas/admin/Content/admin.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datepicker").Include(
                "~/Content/bootstrap-datepicker3*"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/font-awesome*"));
        }
    }
}