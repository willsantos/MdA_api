using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Http;


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
        public async Task<ObjetivoResponse> Post(ObjetivoRequest request)
        {
            var usuario = await _usuarioRepository.FindAsync(x => x.Id == UsuarioId && x.Ativo == true);
            var objetivo = _mapper.Map<Objetivo>(request);
            objetivo.DataCriacao = DateTime.Now;
            var objetoACadastrar = await _objetivoRepository.AddAsync(objetivo);
            return _mapper.Map<ObjetivoResponse>(objetoACadastrar);
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

        public Task<ObjetivoResponse> Put(ObjetivoRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
