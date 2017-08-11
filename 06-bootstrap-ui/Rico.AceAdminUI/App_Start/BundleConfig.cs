using System.Web.Optimization;

namespace Rico.AceAdminUI
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jQuery 
            bundles.Add(new ScriptBundle("~/Content/Scripts/jquery").Include(
                        "~/Content/Scripts/jquery/jquery-2.0.3.min.js"));

            //Ace脚本
            bundles.Add(new ScriptBundle("~/Content/ace/js").Include(
                    "~/Content/ace/js/ace.js",
                    "~/Content/ace/js/ace-elements.js",
                    "~/Content/ace/js/ace-extra.js"));
            //Ace样式
            bundles.Add(new StyleBundle("~/Content/ace/css").Include(
                     "~/Content/ace/css/ace-fonts.css",
                     "~/Content/ace/css/ace.min.css",
                     "~/Content/ace/css/ace-skins.min.css",
                     "~/Content/ace/css/ace-rtl.min.css",
                     "~/Content/ace/css/ace-extra.min.css"));

            //bootstrap 样式
            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                     "~/Content/bootstrap/css/bootstrap-3.0.1.min.css"));
            //bootstrap 脚本
            bundles.Add(new ScriptBundle("~/Content/bootstrap/js").Include(
                        "~/Content/bootstrap/js/bootstrap.3.2.min.js"));

        }
    }
}