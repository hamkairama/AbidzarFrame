using StructureMap;
using StructureMap.Graph;
using System;
using System.Web.Mvc;
using StructureMap.Graph.Scanning;
using StructureMap.TypeRules;

namespace AbidzarFrame.Mvc.Infrastructures.ApplicationRegistry
{
    public class ControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            SetUniqueLifeCycle(type, registry);
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes())
            {
                SetUniqueLifeCycle(type, registry);
            }
        }

        private void SetUniqueLifeCycle(Type type, Registry registry)
        {
            if (!type.IsAbstract && (typeof(IView).IsAssignableFrom(type) || type.CanBeCastTo<Controller>()))
            {
                registry.For(type).LifecycleIs(new StructureMap.Pipeline.UniquePerRequestLifecycle());
            }
        }
    }
}
