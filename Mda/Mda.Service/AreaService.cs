﻿using AutoMapper;
using Mda.Domain.Entities;
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
        public async Task<AreaResponse> Post(AreaRequestInicio request)
        {
            var requestArea = _mapper.Map<Area>(request);
            var AreaCadastrada = await _areaRepository.AddAsync(requestArea);
            return _mapper.Map<AreaResponse>(AreaCadastrada);
        }
        public async Task<AreaResponse> GetById(Guid id)
        {
            var AreaEncontrada = await _areaRepository.FindAsync(x => x.Id == id && x.Roda.UsuarioId == UsuarioId);
            if(AreaEncontrada == null)
            {
                throw new ArgumentException("Você não tem área cadastrada");
            }
            if(AreaEncontrada.Ativo == false)
            {
                throw new ArgumentException("A respectiva Area buscada foi deletada logicamente");
            }
            return _mapper.Map<AreaResponse>(AreaEncontrada);            
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AreaResponse>> Get()
        {
            throw new NotImplementedException();
        }                  

        public Task<AreaResponse> Put(AreaRequestInicio request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
