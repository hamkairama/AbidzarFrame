using System.Web;
using StructureMap;

namespace AbidzarFrame.Mvc.Infrastructures.DI
{
    public static class ContainerPerRequestExtension
    {
        public static IContainer GetContainer(this HttpContextBase context)
        {
            return (IContainer)HttpContext.Current.Items["_Container"] ?? IoC.Container;
        }

    }
}
