using StructureMap;
using StructureMap.Graph;

namespace AbidzarFrame.Mvc.Infrastructures.ApplicationRegistry
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
            });
        }
    }
}
