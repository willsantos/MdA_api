﻿using Mda.Domain.Entities.Utils;
using Mda.Domain.Interfaces;
using Mda.Domain.UsuarioContratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjetivoController : ControllerBase
    {
        private IObjetivoService _objetivoService;

        public ObjetivoController(IObjetivoService objetivoService)
        {
            _objetivoService = objetivoService;
        }

        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma novo Objetivo no banco.", Description = "Retorna dados do Objetivo.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ObjetivoResponse>> Post([FromBody] ObjetivoRequest request)
        {
            try
            {
                var result = await _objetivoService.Post(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca Objetivo Por id", Description = "Retorna Objetivo se ele for encontrado. Se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ObjetivoResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _objetivoService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
