using System.Web.Mvc;
using StructureMap;
using AbidzarFrame.Mvc.Infrastructures.ModelMetadata;
using StructureMap.Graph;

namespace AbidzarFrame.Mvc.Infrastructures.ApplicationRegistry
{
    public class ModelMetadataRegistry : Registry
    {
        public ModelMetadataRegistry()
        {
            For<ModelMetadataProvider>().Use<ExtensibleModelMetadataProvider>();

            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IModelMetadataFilter>();
            });
        }
    }
}
