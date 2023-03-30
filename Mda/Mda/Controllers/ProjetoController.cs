using Mda.Domain.Contratos;
using Mda.Domain.Entities.Utils;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Mda.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;

namespace Mda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma novo projeto no banco.", Description = "Retorna dados do projeto.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProjetoResponse>> Post([FromBody] ProjetoRequest request)
        {
            try
            {
                var result = await _projetoService.Post(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca Projetp Por id", Description = "Retorna Projeto se ele for encontrado. Se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProjetoResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _projetoService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Busca Todos Os Projetos ativos.", Description = "Retorna todos os projetos Ativos.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProjetoResponse>>> Get()
        {
            try
            {
                var result = await _projetoService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
