using System.Web;
using System.Web.Optimization;

namespace Rico.BootstrapSamples
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region
            //2.bootstrap
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                        "~/Content/bootstrap/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/Content/js/bootstrap").Include(
                        "~/Content/bootstrap/bootstrap.js"));

            //3.bootstrap-table
            bundles.Add(new StyleBundle("~/Content/bootstrap-table/css").Include(
                        "~/Content/bootstrap-table/bootstrap-table.css"));
            bundles.Add(new ScriptBundle("~/Content/bootstrap-table/js").Include(
                        "~/Content/bootstrap-table/bootstrap-table.js",
                        "~/Content/bootstrap-table/locale/bootstrap-table-zh-CN.js"));
            #endregion
        }
    }
}
