using AutoMapper;
using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Domain.Shared;
using Mda.Domain.UsuarioContratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Service
{
   public class UsuarioService :IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> GetById(int id)
        {
            throw new NotImplementedException();
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
