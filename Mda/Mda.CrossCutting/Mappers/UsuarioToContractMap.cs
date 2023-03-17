using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.UsuarioContratos;

namespace Mda.CrossCutting.Mappers
{
    public class UsuarioToContractMap : Profile
    {
        public UsuarioToContractMap()
        {
            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Usuario, UsuarioRequestRole>().ReverseMap();
        }
       
    }
}
