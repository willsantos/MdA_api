using AutoMapper;
using Mda.Domain.Contratos;
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

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TarefaResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TarefaResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TarefaResponse> Post(TarefaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TarefaResponse> Put(TarefaRequest request, Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
