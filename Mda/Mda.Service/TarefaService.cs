using AutoMapper;
using Mda.Domain.Contratos;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Service
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public TarefaService(IHttpContextAccessor httpContextAccessor,
                             ITarefaRepository tarefaRepository,
                             IProjetoRepository projetoRepository,
                             IUsuarioRepository usuarioRepository, IMapper mapper) : base(httpContextAccessor)
        {
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<TarefaResponse> Post(TarefaRequest request)
        {
            var tarefaRequest = _mapper.Map<Tarefa>(request);
            var TarefaCadastrada = await _tarefaRepository.AddAsync(tarefaRequest);
            return _mapper.Map<TarefaResponse>(tarefaRequest);

        }
        public async Task<TarefaResponse> Put(TarefaRequest request, Guid? id)
        {
            var tarefaEncontrada = await _tarefaRepository.FindAsync(x => x.Id == id && x.Projeto
                                                                                         .Objetivo
                                                                                         .Area.Roda.UsuarioId == UsuarioId);
            if (tarefaEncontrada == null)
            {

                throw new ArgumentException("Essa Tarefa não está cadastrada ou você não tem acesso");

            }
            tarefaEncontrada = _mapper.Map<Tarefa>(request);
            tarefaEncontrada.DataAtualizacao = DateTime.Now;
            await _tarefaRepository.EditAsync(tarefaEncontrada);
            return _mapper.Map<TarefaResponse>(tarefaEncontrada);
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TarefaResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TarefaResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
