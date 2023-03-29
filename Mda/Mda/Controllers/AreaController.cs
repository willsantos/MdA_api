using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Mda.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    }
}
