using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Kegiatan
{
    public class KegiatanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Kegiatan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Kegiatan_default",
                "Kegiatan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}