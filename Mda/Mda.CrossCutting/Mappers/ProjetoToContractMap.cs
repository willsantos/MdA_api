using AutoMapper;
using Mda.Domain.Contratos;
using Mda.Domain.Entities;
using Mda.Domain.UsuarioContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.CrossCutting.Mappers
{
    public class ProjetoToContractMap : Profile

    {
        public ProjetoToContractMap()
        {
            CreateMap<Projeto, ProjetoRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoResponse>().ReverseMap();
        }
    }
}
