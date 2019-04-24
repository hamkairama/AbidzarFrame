using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Kependudukan
{
    public class KependudukanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Kependudukan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Kependudukan_default",
                "Kependudukan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}