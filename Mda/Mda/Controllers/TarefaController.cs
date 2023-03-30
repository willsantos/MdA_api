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

        /// <summary>
        /// Realiza cadastro de nova Tarefa.
        /// </summary>
        /// <returns>Tarefa cadastrada</returns>
        /// <response code="201">Retorna Tarefa Cadastrada</response>
        /// <response code="400">Se o item não for criado</response> 
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
        /// <summary>
        /// Realiza busca de Tarefa por Id.
        /// </summary>
        /// <returns>Tarefa</returns>
        /// <response code="200">Retorna Tarefa</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
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

        /// <summary>
        /// Realiza busca de todas as Tarefas.
        /// </summary>
        /// <returns>Tarefass</returns>
        /// <response code="200">Retorna Tarefass</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
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
        /// <summary>
        /// Busca Tarefa e realiza mudança de dados.
        /// </summary>   
        ///<returns>Tarefa modificada</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca Tarefa para mudança de dados.", Description = "Retorna Tarefa modificada.")]
        public async Task<ActionResult<TarefaResponse>> Put([FromBody] TarefaRequest tarefaAlteracao, [FromRoute] Guid id)
        {
            try
            {
                var result = await _tarefaService.Put(tarefaAlteracao, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Deleta Tarefa.
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
                await _tarefaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
