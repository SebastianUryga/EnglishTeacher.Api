using AutoMapper;
using System.Reflection;

namespace EnglishTeacher.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingfromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingfromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(type => 
                type.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapForm<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}
