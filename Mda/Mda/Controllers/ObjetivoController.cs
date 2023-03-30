using Mda.Domain.Entities.Utils;
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

        /// <summary>
        /// Realiza cadastro de novo Objetivo.
        /// </summary>
        /// <returns>Objetivo cadastrada</returns>
        /// <response code="201">Retorna Ibjetivo Cadastrado</response>
        /// <response code="400">Se o item não for criado</response> 
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

        /// <summary>
        /// Realiza busca de objetivo por Id.
        /// </summary>
        /// <returns>Objetivo</returns>
        /// <response code="200">Retorna Objetivo</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
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

        /// <summary>
        /// Realiza busca de todos os Objetivos.
        /// </summary>
        /// <returns>Objetivo</returns>
        /// <response code="200">Retorna Objetivo</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [HttpGet]
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [SwaggerOperation(Summary = "Busca Todos Os Objetivos ativos.", Description = "Retorna todos os objetivos Ativos.")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ObjetivoResponse>>> Get()
        {
            try
            {
                var result = await _objetivoService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Busca Objetivo e realiza mudança de dados.
        /// </summary>   
        ///<returns>Objetivo modificado</returns>
        /// <response code="200">Se o objeto existe e foi alterado</response>
        /// <response code="404">Se o objeto não existe</response>
        /// <response code="403">Se o acesso for negado</response>
        [Authorize(Roles = ConstantUtil.PerfilLogadoNome)]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Busca Objetivo para mudança de dados.", Description = "Retorna Objetivo modificada.")]
        public async Task<ActionResult<ObjetivoResponse>> Put([FromBody] ObjetivoRequest objetivoAlteracao, [FromRoute] Guid id)
        {
            try
            {
                var result = await _objetivoService.Put(objetivoAlteracao, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Deleta Objetivo.
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
                await _objetivoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
