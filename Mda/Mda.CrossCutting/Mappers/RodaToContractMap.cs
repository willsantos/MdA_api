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
    public class RodaToContractMap : Profile
    {
        public RodaToContractMap()
        {
            CreateMap<Roda, RodaRequest>().ReverseMap();
            CreateMap<Roda, RodaResponse>().ReverseMap();
        }
    }
}
