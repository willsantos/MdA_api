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
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        public ProjetoService(IHttpContextAccessor httpContextAccessor,
                              IProjetoRepository projetoRepository,
                              ITarefaRepository tarefaRepository, IMapper mapper) : base(httpContextAccessor)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }
        public async Task<ProjetoResponse> Post(ProjetoRequest request)
        {
            var projetoEntity = _mapper.Map<Projeto>(request);
            var projetoCadastrado = await _projetoRepository.AddAsync(projetoEntity);
            return _mapper.Map<ProjetoResponse>(projetoCadastrado);
        }
        public async Task<ProjetoResponse> Put(ProjetoRequest request, Guid? id)
        {
            var projetoEncontrado = await _projetoRepository.FindAsync(x => x.Id == id && x.Objetivo.Area.Roda.UsuarioId == UsuarioId);            
            if(projetoEncontrado == null)
            {
                throw new ArgumentException("Esse projeto não está cadastrado ou você não tem acesso");
            }
            projetoEncontrado = _mapper.Map<Projeto>(request);
            projetoEncontrado.DataAtualizacao = DateTime.Now;
            await _projetoRepository.EditAsync(projetoEncontrado);
            return _mapper.Map<ProjetoResponse>(projetoEncontrado);
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjetoResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProjetoResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
       
    }
}
