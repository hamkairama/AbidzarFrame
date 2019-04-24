using System.Web;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Optimization;
using StructureMap;

namespace AbidzarFrame.Mvc.Infrastructures.ApplicationRegistry
{
    public class MvcRegistry : Registry
    {

        public MvcRegistry()
        {
            For<BundleCollection>().Use(BundleTable.Bundles);
            For<RouteCollection>().Use(RouteTable.Routes);
            For<HttpSessionStateBase>().Use(()=> new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
            For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
        }
    }
}
