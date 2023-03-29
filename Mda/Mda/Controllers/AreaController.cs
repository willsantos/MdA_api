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

        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova Area no banco.", Description = "Retorna dados da Area.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<AreaResponse>> Post([FromBody] AreaRequestInicio area)
        {
            try
            {
                var result = await _areaService.Post(area);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
