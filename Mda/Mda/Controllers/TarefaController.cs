using Mda.Domain.Contratos;
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
    public class TarefaController : ControllerBase
    {
        private ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaservice)
        {
            _tarefaService = tarefaservice;
        }

        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova Tarefa no banco.", Description = "Retorna dados da Tarefa.")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TarefaResponse>> Post([FromBody] TarefaRequest tarefa)
        {
            try
            {
                var result = await _tarefaService.Post(tarefa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca Tarefa Por id", Description = "Retorna a Tarefa se ela for encontrada. Se não, retorna exception.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TarefaResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _tarefaService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Busca Todos As Tarefas ativas.", Description = "Retorna todas as Tarefas Ativas.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<TarefaResponse>>> Get()
        {
            try
            {
                var result = await _tarefaService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
