using System.Web;
using System.Web.Optimization;

namespace CodeProject.Portal
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
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/SortableGrid.css",
                      "~/Content/angular-block-ui.min.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
               "~/Scripts/angular.min.js",
               "~/Scripts/angular-route.min.js",
               "~/Scripts/angular-sanitize.min.js",
               "~/Scripts/angular-ui.min.js",
               "~/Scripts/angular-ui/ui-bootstrap.min.js",
               "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
               "~/Scripts/angular-ui.min.js",       
               "~/Scripts/angular-block-ui.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/shared").Include(
               "~/Views/Shared/CodeProjectBootstrap.js",
                "~/Views/Shared/AjaxService.js",
                "~/Views/Shared/AlertService.js",
                "~/Views/Shared/DataGridService.js",
                "~/Views/Shared/MasterController.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/routing-debug").Include(
              "~/Views/Shared/CodeProjectRouting-debug.js"
          ));

            bundles.Add(new ScriptBundle("~/bundles/routing-production").Include(
             "~/Views/Shared/CodeProjectRouting-production.js"
         ));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                "~/Views/Home/IndexController.js",
                "~/Views/Home/AboutController.js",
                "~/Views/Home/ContactController.js",
                "~/Views/Home/InitializeDataController.js"
         ));


            bundles.Add(new ScriptBundle("~/bundles/customers").Include(
              "~/Views/Customers/CustomerDummyController01.js",
              "~/Views/Customers/CustomerDummyController02.js",
              "~/Views/Customers/CustomerDummyController03.js",
              "~/Views/Customers/CustomerDummyController04.js",
              "~/Views/Customers/CustomerDummyController05.js",
              "~/Views/Customers/CustomerDummyController06.js",
              "~/Views/Customers/CustomerDummyController07.js",
              "~/Views/Customers/CustomerDummyController08.js",
              "~/Views/Customers/CustomerDummyController09.js",
              "~/Views/Customers/CustomerDummyController10.js",
              "~/Views/Customers/CustomerMaintenanceController.js",
              "~/Views/Customers/CustomerInquiryController.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/products").Include(      
                "~/Views/Products/ProductMaintenanceController.js",
                "~/Views/Products/ProductInquiryController.js"
            ));

        }
    }
}
