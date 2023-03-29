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
    public class AreaController : ControllerBase
    {
        private IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova Area no banco.", Description = "Retorna dados da Area.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<UsuarioResponse>> Post([FromBody] AreaRequestInicio area)
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
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
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
    }
}
