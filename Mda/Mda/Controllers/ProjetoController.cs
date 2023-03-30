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

        /// <summary>
        /// Realiza cadastro de novo projeto.
        /// </summary>
        /// <returns>Projeto cadastrado</returns>
        /// <response code="201">Retorna Projeto Cadastrado</response>
        /// <response code="400">Se o item não for criado</response> 
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

        /// <summary>
        /// Realiza busca de projeto por Id.
        /// </summary>
        /// <returns>Projeto</returns>
        /// <response code="200">Retorna projeto</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
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

        /// <summary>
        /// Realiza busca de todos os projetos.
        /// </summary>
        /// <returns>Projetos</returns>
        /// <response code="200">Retorna Projetos</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
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

        /// <summary>
        /// Busca Projeto e realiza mudança de dados.
        /// </summary>   
        ///<returns>Projeto modificado</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca projeto para mudança de dados.", Description = "Retorna Projeto modificado.")]
        public async Task<ActionResult<ProjetoResponse>> Put([FromBody] ProjetoRequest projetoAlteracao, [FromRoute] Guid id)
        {
            try
            {
                var result = await _projetoService.Put(projetoAlteracao, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Deleta Projeto.
        /// </summary>            
        /// <response code="200">Se o objeto existe</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _projetoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
