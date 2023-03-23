using Mda.CrossCutting.Mappers;
using Mda.Domain.Interfaces;
using Mda.Repository.Context;
using Mda.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Mda.CrossCutting.DependencyInjector
{
    public class ConfigureRepository
    {
              

        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<IRodaRepository, RodaRepository>();
            serviceCollection.AddScoped<IAreaRepository, AreaRepository>();
            serviceCollection.AddScoped<IObjetivoRepository, ObjetivoRepository>();
            serviceCollection.AddScoped<IProjetoRepository, ProjetoRepository>();
            serviceCollection.AddScoped<ITarefaRepository, TarefaRepository>();
            serviceCollection.AddScoped<ICodigoRepository, CodigoRepository>();
           
        }
    }

}

