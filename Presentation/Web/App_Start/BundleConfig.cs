using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void Config(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/kendo.all.min.js",
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include("~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.bootstrap.min.css"));

            bundles.IgnoreList.Clear();
        }
    }
}