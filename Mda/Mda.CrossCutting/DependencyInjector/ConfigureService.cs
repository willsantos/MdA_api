using Mda.Domain.Interfaces;
using Mda.Repository.Context;
using Mda.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.CrossCutting.DependencyInjector
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsuarioService, UsuarioService>();
            serviceCollection.AddScoped<IRodaService, RodaService>();
            serviceCollection.AddScoped<IAreaService, AreaService>();
            /*serviceCollection.AddScoped<ITarefaService, TarefaService>();
            serviceCollection.AddScoped<IEmailService, EmailService>();
            serviceCollection.AddScoped<IRelatorioService, RelatorioService>();
            serviceCollection.AddScoped<ITogglService, TogglService>();
            serviceCollection.AddScoped<ILogService, LogService>();*/
            
        }
    }
}
