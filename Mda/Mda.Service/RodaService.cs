using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Http;
using System.Buffers;

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
            //if(usuario.Rodas.Count() == 2)
            var roda = _mapper.Map<Roda>(request);
            roda.DataCriacao = DateTime.Now;
            roda.UsuarioId = (Guid)UsuarioId;
            var rodaCadastrada = await _rodaRepository.AddAsync(roda);
            return _mapper.Map<RodaResponse>(rodaCadastrada);
        }

        public async Task<RodaResponse> GetById(Guid id)
        {
            var roda = await _rodaRepository.FindAsync(x => x.Id == id && x.UsuarioId == UsuarioId);
            if (roda == null)
            {
                throw new Exception("A Roda buscada não existe");
            }
            return _mapper.Map<RodaResponse>(roda);
        }

        public async Task<IEnumerable<RodaResponse>> Get()
        {
            var listRodas = await _rodaRepository.ListAsync(x => x.UsuarioId == UsuarioId);
            return _mapper.Map<IEnumerable<RodaResponse>>(listRodas);
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }      

        public Task<RodaResponse> Put(RodaRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
