﻿using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Http;


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
        public async Task<AreaResponse> Patch(AreaRequestFim request, Guid? Id)
        {
            var areaEcontrada = await _areaRepository.FindAsync(x => x.Id == Id);
            if (areaEcontrada == null)
            {
                throw new ArgumentException("A area referente a esse Id não existe");
            }
            if(areaEcontrada.Roda.UsuarioId != UsuarioId)
            {
                throw new UnauthorizedAccessException("Você não tem autorização");
            }
            var requestArea = _mapper.Map<Area>(request);
            requestArea.DataAtualizacao = DateTime.Now;
            areaEcontrada = requestArea;
            var AreaCadastrada = await _areaRepository.EditAsync(areaEcontrada);
            return _mapper.Map<AreaResponse>(AreaCadastrada);
        }
        public async Task<AreaResponse> GetById(Guid id)
        {
            var AreaEncontrada = await _areaRepository.FindAsync(x => x.Id == id && x.Roda.UsuarioId == UsuarioId);
            if (AreaEncontrada == null)
            {
                throw new ArgumentException("Você não tem área cadastrada");
            }
            if (AreaEncontrada.Ativo == false)
            {
                throw new ArgumentException("A respectiva Area buscada foi deletada logicamente");
            }
            return _mapper.Map<AreaResponse>(AreaEncontrada);
        }
        public async Task<IEnumerable<AreaResponse>> Get()
        {
            var listArea = await _areaRepository.ListAsync(x => x.Ativo && x.Roda.UsuarioId == UsuarioId);
            if (listArea == null)
            {
                throw new ArgumentException("Você não tem área cadastrada");
            }
            return _mapper.Map<IEnumerable<AreaResponse>>(listArea);
        }
        public async Task<AreaResponse> Put(AreaRequestInicio request, Guid? id)
        {
            var AreaEncontrada = await _areaRepository.FindAsync(x => x.Id == id);
            if (AreaEncontrada.Roda.UsuarioId == UsuarioId)
            {
                throw new UnauthorizedAccessException("Você não tem autorização");
            }
            if (AreaEncontrada == null)
            {
                throw new ArgumentException("Essa Area não está cadastrada");
            }
            AreaEncontrada = _mapper.Map<Area>(request);
            AreaEncontrada.DataAtualizacao = DateTime.Now;
            await _areaRepository.EditAsync(AreaEncontrada);
            return _mapper.Map<AreaResponse>(AreaEncontrada);
        }
        public async Task Delete(Guid Id)
        {
            var AreaEncontrada = await _areaRepository.FindAsync(x => x.Id == Id && x.Roda.UsuarioId == UsuarioId);
            if (AreaEncontrada == null)
            {
                throw new Exception("Area não existe");
            }
            if (AreaEncontrada.Ativo == false)
            {
                throw new Exception("Area não está ativa");
            }
            AreaEncontrada.Ativo = false;
            AreaEncontrada.DataAtualizacao = DateTime.Now;
            await _areaRepository.EditAsync(AreaEncontrada);
        }

    }
}
