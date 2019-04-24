using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbidzarFrame.Core.Mvc.Models;
using AbidzarFrame.Core.Mvc.Helpers;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Views
{
    public class EnhancedViewUserControl : System.Web.Mvc.ViewUserControl
    {
        protected string CurrentSystemLanguage
        {
            get
            {
                return (string)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
            }
        }

        protected virtual String FormatDecimal(Decimal value)
        {
            return EnhancedViewPage.GetInstance().FormatDecimal(value);
        }

    }

    public class EnhancedViewUserControl<TModel> : System.Web.Mvc.ViewUserControl 
    {
        protected string CurrentSystemLanguage
        {
            get
            {
                return (string)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
            }
        }

        protected virtual String FormatDecimal(Decimal value)
        {
            return EnhancedViewPage.GetInstance().FormatDecimal(value);
        }        

    }

}
