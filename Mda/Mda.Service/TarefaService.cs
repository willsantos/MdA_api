﻿using AutoMapper;
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
                                                                                         .Area.Roda
                                                                                         .UsuarioId == UsuarioId);
            if (tarefaEncontrada == null)
            {

                throw new ArgumentException("Essa Tarefa não está cadastrada ou você não tem acesso");

            }
            tarefaEncontrada = _mapper.Map<Tarefa>(request);
            tarefaEncontrada.DataAtualizacao = DateTime.Now;
            await _tarefaRepository.EditAsync(tarefaEncontrada);
            return _mapper.Map<TarefaResponse>(tarefaEncontrada);
        }
        public async Task<TarefaResponse> GetById(Guid id)
        {
            var tarefaEncontrada = await _tarefaRepository.FindAsync(x => x.Id == id && x.Projeto
                                                                                         .Objetivo
                                                                                         .Area.Roda
                                                                                         .UsuarioId == UsuarioId);
            if (tarefaEncontrada == null)
            {
                throw new ArgumentException("Essa Tarefa não está cadastrada ou você não tem acesso");
            }
            if (tarefaEncontrada.Ativo == false)
            {
                throw new ArgumentException("Essa Tarefa foi deletada logicamente");
            }
            return _mapper.Map<TarefaResponse>(tarefaEncontrada);
        }
        public async Task<IEnumerable<TarefaResponse>> Get()
        {
            var listaTarefas = await _tarefaRepository.ListAsync(x => x.Projeto
                                                                       .Objetivo
                                                                       .Area.Roda
                                                                       .UsuarioId == UsuarioId);
            if (listaTarefas == null)
            {
                throw new ArgumentException("Você não tem tarefas cadastradas");
            }
            return _mapper.Map<IEnumerable<TarefaResponse>>(listaTarefas);
        }
        public async Task Delete(Guid Id)
        {
            var tarefaEncontrada = await _tarefaRepository.FindAsync(x => x.Id == Id && x.Projeto
                                                                                         .Objetivo
                                                                                         .Area.Roda
                                                                                         .UsuarioId == UsuarioId);
            if (tarefaEncontrada == null)
            {
                throw new ArgumentException("Essa Tarefa não está cadastrada ou você não tem acesso");
            }
            if (tarefaEncontrada.Ativo == false)
            {
                throw new ArgumentException("Essa Tarefa já foi deletada logicamente");
            }
            tarefaEncontrada.Ativo = false;
            await _tarefaRepository.EditAsync(tarefaEncontrada);            
        }



    }
}
