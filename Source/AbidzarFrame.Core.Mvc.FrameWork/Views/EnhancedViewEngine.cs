using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Views
{
    public class EnhancedViewEngine : VirtualPathProviderViewEngine
    {

        public const String SYSTEM_LANGUAGE = "__SYSTEM_LANGUAGE";
        public const String LANGUAGE_EN = "en";
        public const String LANGUAGE_ZH = "zh";
        public const String LANGUAGE_VN = "vn";
        public const String LANGUAGE_ID = "id";
        public const String LANGUAGE_KH = "kh";
        public const String LANGUAGE_TH = "th";

        public EnhancedViewEngine() {
            this.ViewLocationFormats = new String[] { "~/Views/en/{1}/{0}.aspx", "~/Views/zh/{1}/{0}.aspx", "~/Views/vn/{1}/{0}.aspx", "~/Views/id/{1}/{0}.aspx", "~/Views/kh/{1}/{0}.aspx", "~/Views/th/{1}/{0}.aspx" };
            this.PartialViewLocationFormats = new String[] { "~/Views/en/{1}/{0}.aspx", "~/Views/zh/{1}/{0}.aspx", "~/Views/vn/{1}/{0}.aspx", "~/Views/id/{1}/{0}.aspx", "~/Views/kh/{1}/{0}.aspx", "~/Views/th/{1}/{0}.aspx",
                                                             "~/Views/en/{1}/{0}.ascx", "~/Views/zh/{1}/{0}.ascx", "~/Views/vn/{1}/{0}.ascx", "~/Views/id/{1}/{0}.ascx", "~/Views/kh/{1}/{0}.ascx", "~/Views/th/{1}/{0}.ascx"};  
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            String language = GetLanguage(controllerContext);
            String newPath = GetLanguageViewPath(language, partialPath);
            return new WebFormView(controllerContext, newPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            String language = GetLanguage(controllerContext);
            String newPath = GetLanguageViewPath(language, viewPath);
            return new WebFormView(controllerContext, newPath, masterPath);
        }

        protected virtual String GetLanguage(ControllerContext controllerContext)
        {
            String language = (String)controllerContext.HttpContext.Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
            if (language == null) {
                language = LANGUAGE_EN;
            }
            return language;
        }
        
        protected virtual String GetLanguageViewPath(String language, String viewPath) {
            String[] phases = viewPath.Split('/');
            phases[2] = language;
            String modifiedPath = String.Join("/", phases);

            return modifiedPath;
        }

    }

}
