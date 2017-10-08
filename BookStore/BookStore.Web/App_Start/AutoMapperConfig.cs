using AutoMapper;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookStore.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapperConfigurationExpression Configuration { get; private set; }

        public void Execute(Assembly assembly)
        {
            Mapper.Initialize(
                cfg =>
                {
                    var types = assembly.GetExportedTypes();
                    LoadStandartMappings(types, cfg);
                    LoadCustomMappings(types, cfg);
                    Configuration = cfg;
                });
        }

        private void LoadStandartMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Sourse = i.GetGenericArguments()[0],
                            Destination = t
                        })
                        .ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Sourse, map.Destination);
                mapperConfiguration.CreateMap(map.Destination, map.Sourse);
            }
        }

        private void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }

        }
    }
}