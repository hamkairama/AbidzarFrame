using AutoMapper;
using AbidzarFrame.Mvc.Infrastructures.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AbidzarFrame.Mvc.Infrastructures.Mapping
{
    public class AutoMapperConfig //: IRunAtInit
    {
        public void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            LoadStandardMappings(types);

            LoadCustomMappings(types);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            //Mapper.Initialize(cfg =>
            //{
            //    foreach (var map in maps)
            //    {
            //        cfg.CreateMap(map.Source, map.Destination);
            //    }
            //});

            // obsolute di veri 4.0.4
            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                 map.CreateMappings(Mapper.Configuration);
            }
        }
    }

}
