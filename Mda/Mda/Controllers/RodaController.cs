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
    public class RodaController : ControllerBase
    {
        private readonly IRodaService _rodaService;

        public RodaController(IRodaService rodaService)
        {
            _rodaService = rodaService;
        }
        [HttpPost]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Cadastra um nova Roda no banco.", Description = "Retorna dados da Roda.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<RodaResponse>> Post([FromBody] RodaRequest roda)
        {
            var result = await _rodaService.Post(roda);
            return Ok(result);
        }
    }
}
