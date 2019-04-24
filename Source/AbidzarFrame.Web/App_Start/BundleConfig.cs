using System.Web;
using System.Web.Optimization;

namespace AbidzarFrame.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLayout(bundles);

            RegisterElements(bundles);

            RegisterShared(bundles);

            // RegisterForms(bundles);
        }

        private static void RegisterLayout(BundleCollection bundles)
        {
            //// GLOBAL MANDATORY STYLES
            
            #region component-rounded
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/components-rounded/css").Include(
                "~/Content/Layout/css/components-rounded.css", new CssRewriteUrlTransform()
                ));
            #endregion

            // THEMES STYLE
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/themes-style").Include(
                "~/Content/Layout/css/plugins.css",
                "~/Content/Layout/css/layout.css",
                "~/Content/Layout/css/themes/light.css",
                "~/Content/Layout/css/custom.css"));

            #region Themes style
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/themes/plugins/css").Include(
                "~/Content/Layout/css/plugins.css", new CssRewriteUrlTransform()
                ));
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/themes/layout/css").Include(
               "~/Content/Layout/css/layout.css", new CssRewriteUrlTransform()
               ));
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/themes/light/css").Include(
               "~/Content/Layout/css/themes/light.css", new CssRewriteUrlTransform()
               ));
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/themes/custom/css").Include(
               "~/Content/Layout/css/custom.css", new CssRewriteUrlTransform()
               ));
            #endregion

            #region login style
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/login/css").Include(
                "~/Content/Layout/css/login-soft.css", new CssRewriteUrlTransform()
                ));
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/login/js").Include(
                "~/Content/Layout/scripts/login-soft.js"
                ));
            #endregion
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/metro/js").Include(
               "~/Content/Layout/scripts/metronic.js",
               "~/Content/Layout/scripts/layout.js",
               "~/Content/Layout/scripts/ui-tree.js"));
        }

        private static void RegisterElements(BundleCollection bundles)
        {
            #region Jquery
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery/js").Include(                 
                 "~/Scripts/jquery/jquery-2.2.4.min.js"
                 //"~/Scripts/jquery/jquery-3.3.1.min.js"
                ));
            #endregion

            #region Jquery-ui
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/jquery-ui/css").Include(
                "~/Content/plugins/jquery-ui/css/jquery-ui.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-ui/js").Include(
                 "~/Content/plugins/jquery-ui/js/jquery-ui.min.js"
                ));
            #endregion

            #region Jquery-validation
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-validation/js").Include(
                "~/Content/plugins/jquery-validation/js/jquery.validate.min.js",
                "~/Content/plugins/jquery-validation/js/additional-methods.min.js"));
            #endregion

            #region Jquery-slimscroll
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-slimscroll/js").Include(
                 "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.min.js"
                ));
            #endregion

            #region Font-awesome
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/font-awesome/css").Include(
                 "~/Content/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
                ));
            #endregion

            #region Simple-line-icons
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/simple-line-icons/css").Include(
                 "~/Content/plugins/simple-line-icons/css/simple-line-icons.min.css", new CssRewriteUrlTransform()
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/simple-line-icons/js").Include(
                 "~/Content/plugins/simple-line-icons/js/icons-lte-ie7.js"
                ));
            #endregion

            #region Uniform
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/uniform/css").Include(
                "~/Content/plugins/uniform/css/uniform.default.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/uniform/js").Include(
                 "~/Content/plugins/uniform/js/jquery.uniform.min.js"
                ));
            #endregion

            #region Bootstrap
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap/css").Include(
                "~/Content/plugins/bootstrap/css/bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap/js").Include(
                 "~/Content/plugins/bootstrap/js/bootstrap.min.js"
                ));
            #endregion

            #region Bootstrap-switch
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap-switch/css").Include(
                "~/Content/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap-switch/js").Include(
                 "~/Content/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                ));
            #endregion

            #region Bootstrap-select
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap-select/css").Include(
                "~/Content/plugins/bootstrap-select/css/bootstrap-select.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap-select/js").Include(
                 "~/Content/plugins/bootstrap-select/js/bootstrap-select.min.js"
                ));
            #endregion

            #region Bootstrap-toastr
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap-toastr/css").Include(
                "~/Content/plugins/bootstrap-toastr/css/toastr.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap-toastr/js").Include(
                 "~/Content/plugins/bootstrap-toastr/js/toastr.min.js"
                ));
            #endregion

            #region Bootstrap-hover-dropdown
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap-hover-dropdown/js").Include(
                "~/Content/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js"
               ));
            #endregion

            #region Bootbox
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootbox/js").Include(
                 "~/Content/plugins/bootbox/bootbox.min.js"
                ));
            #endregion

            #region Select2
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/select2/css").Include(
                "~/Content/plugins/select2/css/select2.min.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/select2/js").Include(
                 "~/Content/plugins/select2/js/select2.min.js"
                ));
            #endregion

            #region backstretch

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/backstretch/js").Include(
                 "~/Scripts/jquery-backstretch/jquery.backstretch.min.js"
                ));
            #endregion

            #region Jquery Datatable
            // plugins | datatables
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/datatables/js").Include(
                                         "~/Content/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/Content/plugins/datatables/js/dataTables.bootstrap.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/dataTables.buttons.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/buttons.flash.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/jszip.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/pdfmake.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/vfs_fonts.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/buttons.html5.min.js",
                                         "~/Content/plugins/datatables/js/extensions/Export/buttons.print.min.js"));

            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/datatables/css").Include(
                                        "~/Content/plugins/datatables/css/dataTables.bootstrap.css",
                                        "~/Content/plugins/datatables/css/button.dataTables.min.css"));
            #endregion

            #region Jquery validate.unobtrusive
            // plugins | validate.unobtrusive
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-validate-unobtrusive/js").Include(
                                         "~/Scripts/jquery-validate-unobtrusive/jquery.validate.unobtrusive.min.js"));
            #endregion

            #region Bootstrap-datepicker
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap-datepicker/css").Include(
                "~/Content/plugins/bootstrap-datepicker/css/datepicker.css"
                ));

            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/bootstrap-datepicker3/css").Include(
                "~/Content/plugins/bootstrap-datepicker/css/datepicker3.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/bootstrap-datepicker/js").Include(
                 "~/Content/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"
                ));
            #endregion

            #region Jquery-Masking
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-masking/js").Include(
                 "~/Content/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"
                ));
            #endregion

            #region Jquery-Migrate
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-migrate/js").Include(
                 "~/Scripts/jquery-migrate/jquery.migrate-3.0.0.min.js"));
            #endregion

            #region Jquery-BlockUI
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-blockui/js").Include(
                 "~/Scripts/jquery-blockui/jquery.blockui.min.js"));
            #endregion

            #region Jquery-Auto-Numeric
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jquery-autonumeric/js").Include(
                 "~/Content/plugins/jquery-numeric/autoNumeric-1.9.41.js"));
            #endregion

            #region Dropzone
            bundles.Add(new StyleBundle("~/AbidzarFrame/bundles/dropzone/css").Include(
                "~/Content/plugins/dropzone/css/dropzone.css"
                ));

            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/dropzone/js").Include(
                 "~/Content/plugins/dropzone/metronic.js",
                 "~/Content/plugins/dropzone/dropzone.js",
                 "~/Content/plugins/dropzone/form-dropzone.js"
                ));
            #endregion

            #region JsTree
            bundles.Add(new ScriptBundle("~/AbidzarFrame/bundles/jstree/js").Include(
                 "~/Content/plugins/jstree/dist/jstree.js"));
            #endregion

        }
    }
}
