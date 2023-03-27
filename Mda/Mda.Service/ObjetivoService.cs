using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Mda.Repository.Repositories;
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
            var objetivoACadastrar = await _objetivoRepository.AddAsync(objetivo);
            return _mapper.Map<ObjetivoResponse>(objetivoACadastrar);
        }
        public async Task<ObjetivoResponse> GetById(Guid id)
        {
            var objetivo = await _objetivoRepository.FindAsync(x => x.Id == id && x.Area.Roda.UsuarioId == UsuarioId);
            if(objetivo == null)
            {
                throw new Exception("O objetivo buscado não existe ou você não tem acesso");
            }
            return _mapper.Map<ObjetivoResponse>(objetivo);
        }
        public async Task<IEnumerable<ObjetivoResponse>> Get()
        {
            var listaObjetivos = await _objetivoRepository.ListAsync(x => x.Area.Roda.UsuarioId == UsuarioId);
            if (listaObjetivos == null)
            {
                throw new Exception("O objetivo buscado não existe ou você não tem acesso");
            }
            return _mapper.Map<IEnumerable<ObjetivoResponse>>(listaObjetivos);
        }
        public async Task<ObjetivoResponse> Put(ObjetivoRequest request, Guid? id)
        {
            var objetivoEncontrado = await _objetivoRepository.FindAsync(x => x.Id == id && x.Area.Roda.UsuarioId == UsuarioId);
            objetivoEncontrado = _mapper.Map<Objetivo>(request);
            if(objetivoEncontrado == null)
            {
                throw new Exception("O objetivo buscado não existe ou você não tem acesso");
            }
            if (objetivoEncontrado.Ativo == false)
            {
                throw new Exception("Esse objetivo está inativo");
            }
            objetivoEncontrado.DataCriacao = DateTime.Now;
            await _objetivoRepository.EditAsync(objetivoEncontrado);
            return _mapper.Map<ObjetivoResponse>(objetivoEncontrado);
            
        }

        public async Task Delete(Guid Id)
        {
            var objetivoEncontrado = await _objetivoRepository.FindAsync(x => x.Id == Id && x.Area.Roda.UsuarioId == UsuarioId);
            if (objetivoEncontrado == null)
            {
                throw new Exception("O objetivo buscado não existe ou você não tem acesso");
            }
            if (objetivoEncontrado.Ativo == false)
            {
                throw new Exception("Esse objetivo já está inativo");
            }
            objetivoEncontrado.Ativo = false;
            objetivoEncontrado.DataAtualizacao = DateTime.Now;            
        }              
               
    }
}
