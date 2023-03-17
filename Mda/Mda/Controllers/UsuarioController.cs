using Mda.Domain.Entities.Utils;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;

namespace Mda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService service)
        {
            _usuarioService = service;
        }
        /// <summary>
        /// Realiza cadastro de novo usuário.
        /// </summary>
        /// <returns>Usuário cadastrado</returns>
        /// <response code="201">Retorna usuário cadastrado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo usuario no banco.", Description = "Retorna dados do usuario.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<UsuarioResponse>> Post([FromBody] UsuarioRequest usuario)
        {
            var result = await _usuarioService.Post(usuario);
            return Ok(result);
        }

        /// <summary>
        /// Realiza busca de usuário por Id.
        /// </summary>
        /// <returns>Usuário</returns>
        /// <response code="200">Retorna usuário</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um usuário. Por id", Description = "Retorna o usuario se ele for encontrado, e se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<UsuarioResponse>> GetById(Guid id)
        {
            var result = await _usuarioService.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [SwaggerOperation(Summary = "Busca Todos os Usuarios ativos.", Description = "Retorna todos os usuarios Ativos.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UsuarioResponse>>> Get()
        {
            var result = await _usuarioService.Get();
            return Ok(result);
        }
    }
}
