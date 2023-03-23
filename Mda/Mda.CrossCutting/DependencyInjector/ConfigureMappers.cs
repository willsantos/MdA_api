using Mda.CrossCutting.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.CrossCutting.DependencyInjector
{
    public class ConfigureMappers
    {
        public static void ConfigureDependenciesMapper(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cnf =>
            {
                cnf.AddProfile(new UsuarioToContractMap());
                cnf.AddProfile(new AreaToContractMap());
                cnf.AddProfile(new ObjetivoToContractMap());
                cnf.AddProfile(new ProjetoToContractMap());
                cnf.AddProfile(new TarefaToContractMap());
                cnf.AddProfile(new CodigoToContractMap());
                cnf.AddProfile(new RodaToContractMap());

            });

            var mapConfiguration = config.CreateMapper();
            serviceCollection.AddSingleton(mapConfiguration);
        }

    }
}
