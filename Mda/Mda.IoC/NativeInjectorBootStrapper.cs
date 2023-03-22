using Mda.CrossCutting;
using Mda.CrossCutting.DependencyInjector;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureMappers.ConfigureDependenciesMapper(services);
        }

        public static void RegisterAppDependenciesContext(this IServiceCollection services)
        {
            ConfigureRepository.ConfigureDependenciesRepository(services);
        }
        
    }
}
