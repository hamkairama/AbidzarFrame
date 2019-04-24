using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.StrukturOrganisasi
{
    public class StrukturOrganisasiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StrukturOrganisasi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StrukturOrganisasi_default",
                "StrukturOrganisasi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}