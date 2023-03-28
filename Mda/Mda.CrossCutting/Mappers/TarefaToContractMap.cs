using AutoMapper;
using Mda.Domain.Contratos;
using Mda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.CrossCutting.Mappers
{
    public class TarefaToContractMap : Profile
    {
        public TarefaToContractMap()
        {
            CreateMap<Tarefa, TarefaRequest>().ReverseMap();
            CreateMap<Tarefa, TarefaResponse>().ReverseMap();
        }
    }
}
