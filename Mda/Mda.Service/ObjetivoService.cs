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
    public class ObjetivoService : BaseService, IBaseService<ObjetivoRequest, ObjetivoResponse>
    {
        private readonly IObjetivoRepository _objetivoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public ObjetivoService(IHttpContextAccessor httpContextAccessor, 
                               IUsuarioRepository usuarioRepository,
                               IObjetivoRepository objetivoRepository, IMapper mapper) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _objetivoRepository = objetivoRepository;
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ObjetivoResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ObjetivoResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ObjetivoResponse> Post(ObjetivoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ObjetivoResponse> Put(ObjetivoRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
