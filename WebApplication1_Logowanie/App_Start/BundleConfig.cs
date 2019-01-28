using System.Web;
using System.Web.Optimization;

namespace WebApplication1_Logowanie
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Content/themes/base/jquery.ui.datepicker.css",
                       "~/Scripts/jqeuery.validate.js"

                      /* "~/Scripts/jquery.validate.min.js", */
                     /*  "~/Scripts/jquery.unobtrusive-ajax.min.js",*/ 
                    /* "~/Scripts/jquery.unobtrusive - ajax.js"  */));


            bundles.Add(new ScriptBundle("~/bundles/Scripts/createpatientvalidator").Include(
                         "~/Scripts/createpatientvalidator.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                        "~/Scripts/script-custom-validator.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      /*"~/scripts/bootstrap.js", */
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));   
        }
    }
}
