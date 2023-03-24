using AutoMapper;
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
        public async Task<AreaResponse> Post(AreaRequestFim request)
        {
            var requestArea = _mapper.Map<Area>(request);
            requestArea.DataAtualizacao = DateTime.Now;
            var AreaCadastrada = await _areaRepository.EditAsync(requestArea);
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
        public async Task<IEnumerable<AreaResponse>> Get()
        {
            var listArea = await _areaRepository.ListAsync(x => x.Ativo && x.Roda.UsuarioId == UsuarioId);
            if(listArea == null)
            {
                throw new ArgumentException("Você não tem área cadastrada");
            }
            return _mapper.Map<IEnumerable<AreaResponse>>(listArea);
        }
        public async Task<AreaResponse> Put(AreaRequestInicio request, Guid? id)
        {
            var AreaEncontrada = await _areaRepository.FindAsync(x => x.Id == id && x.Roda.UsuarioId == UsuarioId);
            AreaEncontrada = _mapper.Map<Area>(request);
            if (AreaEncontrada == null)
            {
                throw new ArgumentException("Essa Area não está cadastrada ou você não tem acesso");
            }
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
