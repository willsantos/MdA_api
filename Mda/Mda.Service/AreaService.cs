using AutoMapper;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Service
{
    public class AreaService : BaseService, IAreaService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRodaRepository _rodaRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        public AreaService(IHttpContextAccessor httpContextAccessor, 
                           IRodaRepository rodaRepository, 
                           IAreaRepository areaRepository, 
                           IMapper mapper) : base(httpContextAccessor)
        {
            _rodaRepository = rodaRepository;
            _areaRepository = areaRepository;
            _mapper = mapper;
   
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RodaResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<RodaResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RodaResponse> Post(RodaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RodaResponse> Put(RodaRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
