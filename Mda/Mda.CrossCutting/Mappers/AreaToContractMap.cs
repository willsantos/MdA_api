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
    public class AreaToContractMap : Profile
    {
        public AreaToContractMap()
        {
            CreateMap<Area, AreaRequestInicio>().ReverseMap();
            CreateMap<Area, AreaRequestFim>().ReverseMap();
            CreateMap<AreaRequestFim, AreaRequestInicio>().ReverseMap();
        }
    }
}
