using StructureMap;
using StructureMap.Graph;

namespace AbidzarFrame.Mvc.Infrastructures.ApplicationRegistry
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                //scan.Assembly("AbidzarFrame.WCF.Service");
                //scan.Assembly("AbidzarFrame.Parameters");
                //scan.Assembly("AbidzarFrame.DataModel");
                //scan.Assembly("AbidzarFrame.Repository");
            });
        }
    }
}
