using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Entities.Utils;
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

        // criar um patch para mudança de role 
        public async Task Delete(Guid Id)
        {
            var usuario = await _usuarioRepository.FindAsync(x => x.Id == Id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            if (usuario.Ativo == false)
            {
                throw new Exception("Usuario já foi deletado Logicamente");
            }
            if (UsuarioRole == ConstantUtil.PerfilUsuarioAdmin)
            {
                usuario.DataAtualizacao = DateTime.Now;
                usuario.Ativo = false;
                await _usuarioRepository.EditAsync(usuario);
            }

            throw new Exception("Só Administrador pode realizar deleção");
        }

        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            var lista = await _usuarioRepository.ListAsync(x => x.Ativo);
            if (UsuarioRole != ConstantUtil.PerfilUsuarioAdmin)
            {
                throw new Exception("Você não tem acesso ou não está logado");
            }
            return _mapper.Map<IEnumerable<UsuarioResponse>>(lista);
        }

        public async Task<UsuarioResponse> GetById(Guid id)
        {
            var userBase = await _usuarioRepository.FindAsync(x => x.Ativo && x.Id == id);
            if (userBase == null)
            {
                throw new Exception("Usuário não existe ou está inativo");
            }
           if (UsuarioId == id || UsuarioRole == ConstantUtil.PerfilUsuarioAdmin)
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

        public async Task<UsuarioResponse> Put(UsuarioRequest request, Guid? id)
        {
            var usuario = await _usuarioRepository.FindAsync(x => x.Id == id && x.Ativo);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado ou inativo");
            }
            if (UsuarioId == id || UsuarioRole == ConstantUtil.PerfilUsuarioAdmin)
            {
                var refUsuarioAntigo = usuario;
                
                usuario.Nome = request.Nome;
                usuario.Email = request.Email;
                usuario.DataAtualizacao = DateTime.Now;
                await _usuarioRepository.EditAsync(usuario);
                return _mapper.Map<UsuarioResponse>(usuario);

            }
            throw new Exception("Acesso negado");
           
        }
    }

       
    }

