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
    public class RodaController : ControllerBase
    {
        private readonly IRodaService _rodaService;

        public RodaController(IRodaService rodaService)
        {
            _rodaService = rodaService;
        }
        /// <summary>
        /// Realiza cadastro de nova Roda.
        /// </summary>
        /// <returns>Roda cadastrada</returns>
        /// <response code="201">Retorna Roda cadastrada</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Cadastra um nova Roda no banco.", Description = "Retorna dados da Roda.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<RodaResponse>> Post([FromBody] RodaRequest roda)
        {
            try
            {
                var result = await _rodaService.Post(roda);
                return Created(nameof(Post), result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Realiza busca de Roda por Id.
        /// </summary>
        /// <returns>Roda</returns>
        /// <response code="200">Retorna Roda</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca roda Por id", Description = "Retorna roda se ele for encontrado, e se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<RodaResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _rodaService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        /// <summary>
        /// Realiza busca de todos as Rodas.
        /// </summary>
        /// <returns>Rodas</returns>
        /// <response code="200">Retorna Rodass</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [SwaggerOperation(Summary = "Busca todas as rodas.", Description = "Retorna todas as rodas Ativas.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RodaResponse>>> Get()
        {
            try
            {
                var result = await _rodaService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Busca Roda e realiza mudança de dados.
        /// </summary>   
        ///<returns>Roda modificada</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca roda para mudança de dados.", Description = "Retorna a roda modificada.")]
        public async Task<ActionResult<RodaResponse>> Put([FromBody] RodaRequest rodaAlteracao, [FromRoute] Guid id)
        {
            try
            {
                var result = await _rodaService.Put(rodaAlteracao, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Deleta Roda logicamente.
        /// </summary>            
        /// <response code="200">Se o objeto existe</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _rodaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
