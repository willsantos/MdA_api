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
    public class AreaController : ControllerBase
    {
        private IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        /// <summary>
        /// Realiza cadastro de nova Area.
        /// </summary>
        /// <returns>Area cadastrada</returns>
        /// <response code="201">Retorna Area Cadastrada</response>
        /// <response code="400">Se o item não for criado</response> 
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova Area no banco.", Description = "Retorna dados da Area.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<AreaResponse>> Post([FromBody] AreaRequestInicio area)
        {
            try
            {
                var result = await _areaService.Post(area);
                return Created(nameof(Post),result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Realiza busca de Area por Id.
        /// </summary>
        /// <returns>Area</returns>
        /// <response code="200">Retorna Area</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca Area Por id", Description = "Retorna a Area se ela for encontrada. Se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AreaResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _areaService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Realiza busca de todas as Areas.
        /// </summary>
        /// <returns>Areas</returns>
        /// <response code="200">Retorna Areas</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Busca Todos As Areas ativas.", Description = "Retorna todas as Areas Ativas.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AreaResponse>>> Get()
        {
            try
            {
                var result = await _areaService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Busca Area e realiza mudança de dados.
        /// </summary>   
        ///<returns>Area modificada</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca AREA para mudança de dados.", Description = "Retorna Area modificada.")]
        public async Task<ActionResult<AreaResponse>> Put([FromBody] AreaRequestInicio AreaAlteracao, [FromRoute] Guid id)
        {
            try
            {
                var result = await _areaService.Put(AreaAlteracao, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Busca Area e realiza mudança de status
        /// </summary>   
        ///<returns>Area modificada</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca Area para mudança de Status.", Description = "Retorna Area modificada.")]
        public async Task<ActionResult<UsuarioResponse>> Patch([FromRoute] Guid id, [FromBody] AreaRequestFim areaFim)
        {
            try
            {
                var result = await _areaService.Patch(areaFim, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Deleta Area.
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
                await _areaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
