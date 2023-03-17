using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.Shared;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Http;

namespace Mda.Service
{
   public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IHttpContextAccessor httpContextAccessor, IUsuarioRepository usuarioRepository, IMapper mapper) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponse> GetById(Guid id)
        {
            var userBase = await _usuarioRepository.FindAsync(x => x.Ativo && x.Id == id);
            if (userBase == null)
            {
                throw new Exception("Usuário não existe ou está inativo");
            }
           if (UsuarioId == id)
            {
                return _mapper.Map<UsuarioResponse>(userBase);
            }

            throw new Exception("Acesso Negado");
        }
        public async Task<UsuarioResponse> Post(UsuarioRequest request)
        {
            var requestUsuarioEntity = _mapper.Map<Usuario>(request);
            requestUsuarioEntity.Senha = Criptografia.Encrypt(requestUsuarioEntity.Senha);
            var usuarioCadastrado = await _usuarioRepository.AddAsync(requestUsuarioEntity);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }

        public Task<UsuarioResponse> Put(UsuarioRequest request, int? id)
        {
            throw new NotImplementedException();
        }
    }

       
    }

