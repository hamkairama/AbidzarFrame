using AbidzarFrame.Web.App_Start;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionAttribute());
            //filters.Add(new AccessAuthorization());
        }
    }
}
