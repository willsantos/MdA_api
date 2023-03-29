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
            var listRodas = await _rodaRepository.ListAsync();
            if (listRodas == null)
            {
                throw new Exception("Você não tem Rodas Cadastradas");
            }

            return _mapper.Map<IEnumerable<RodaResponse>>(listRodas);
        }         

        public async Task<RodaResponse> Put(RodaRequest request, Guid? id)
        {
            var RodaEncontrada = await _rodaRepository.FindAsync(x => x.Id == id && x.UsuarioId == UsuarioId);
            RodaEncontrada = _mapper.Map<Roda>(request);
            if (RodaEncontrada == null)
            {
                throw new Exception("Roda não existe");
            }
            if (RodaEncontrada.Ativo == false)
            {
                throw new Exception("Roda não está ativa");
            }
            RodaEncontrada.DataAtualizacao = DateTime.Now;
            await _rodaRepository.EditAsync(RodaEncontrada);
            return _mapper.Map<RodaResponse>(RodaEncontrada);
            
        }
        public async Task Delete(Guid Id)
        {
            var RodaEncontrada = await _rodaRepository.FindAsync(x => x.Id == Id && x.UsuarioId == UsuarioId);
            if (RodaEncontrada == null)
            {
                throw new Exception("Roda não existe");
            }
            if (RodaEncontrada.Ativo == false)
            {
                throw new Exception("Roda não está ativa");
            }
            RodaEncontrada.Ativo = false;
            RodaEncontrada.DataAtualizacao = DateTime.Now;
            await _rodaRepository.EditAsync(RodaEncontrada);

        }
    }
}
