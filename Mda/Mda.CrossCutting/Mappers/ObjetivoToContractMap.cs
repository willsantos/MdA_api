using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.UsuarioContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.CrossCutting.Mappers
{
    public class ObjetivoToContractMap : Profile
    {
        public ObjetivoToContractMap()
        {
            CreateMap<Objetivo, ObjetivoRequest>().ReverseMap();
            CreateMap<Objetivo, ObjetivoResponse>().ReverseMap();
        }
    }
}
