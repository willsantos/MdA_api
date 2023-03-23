using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Mda.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Service
{
    public class RodaService : BaseService, IRodaService
    {
        private readonly IRodaRepository _rodaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public RodaService(IHttpContextAccessor httpContextAccessor, 
                           IRodaRepository rodaRepository, 
                           IUsuarioRepository usuarioRepository,
                            IMapper mapper) : base(httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _rodaRepository = rodaRepository;
            _mapper = mapper;
        }

        public async Task<RodaResponse> Post(RodaRequest request)
        {
            var usuario = await _usuarioRepository.FindAsync(x => x.Id == UsuarioId && x.Ativo == true);
            var roda = _mapper.Map<Roda>(request);
            roda.DataCriacao = DateTime.Now;
            roda.UsuarioId = (Guid)UsuarioId;
            var rodaCadastrada = await _rodaRepository.AddAsync(roda);
            return _mapper.Map<RodaResponse>(rodaCadastrada);
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

        public Task<RodaResponse> Put(RodaRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
