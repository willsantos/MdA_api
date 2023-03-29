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
        [HttpPost]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Cadastra um nova Roda no banco.", Description = "Retorna dados da Roda.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<RodaResponse>> Post([FromBody] RodaRequest roda)
        {
            var result = await _rodaService.Post(roda);
            return Ok(result);
        }
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca roda Por id", Description = "Retorna roda se ele for encontrado, e se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<RodaResponse>> GetById(Guid id)
        {
            var result = await _rodaService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [SwaggerOperation(Summary = "Busca todas as rodas.", Description = "Retorna todas as rodas Ativas.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RodaResponse>>> Get()
        {
            var result = await _rodaService.Get();
            return Ok(result);
        }
        [Authorize(Roles = ConstantUtil.PerfilUsuarioAdmin)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca roda para mudança de dados.", Description = "Retorna a roda modificada.")]
        public async Task<ActionResult<RodaResponse>> Put([FromBody] RodaRequest rodaAlteracao, [FromRoute] Guid id)
        {
            var result = await _rodaService.Put(rodaAlteracao, id);
            return Ok(result);
        }
    }
}
