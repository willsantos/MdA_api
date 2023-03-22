﻿using Mda.CrossCutting.Mappers;
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
            /* serviceCollection.AddScoped<IProjetoRepository, ProjetoRepository>();
             serviceCollection.AddScoped<ICodigoConfirmacaoRepository, CodigoConfirmacaoRepository>();
             serviceCollection.AddScoped<IProjetoUsuarioRepository, ProjetoUsuarioRepository>();
             serviceCollection.AddScoped<ITarefaRepository, TarefaRepository>();
             serviceCollection.AddScoped<ITogglRepository, TogglRepository>();
             serviceCollection.AddScoped<ILogRepository, LogRepository>();*/
            /*serviceCollection.AddDbContext<MdaContext>(options => options.UseMySql(_configuration.GetConnectionString(connectionString),
                                                                                   ServerVersion.AutoDetect(connectionString)));*/


        }
    }

}
