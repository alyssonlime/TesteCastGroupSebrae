using API.Entity.Model;
using API.Interface.Service;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ILogger<ContaController> _logger;
        private readonly IContaService _contaService;

        public ContaController(ILogger<ContaController> logger,
            IContaService contaService)
        {
            _logger = logger;
            _contaService = contaService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ViaCepEndereco>> AdicionarAsync([FromBody] Conta conta)
        {
            try
            {
                await _contaService.AdicionarAsync(conta);

                return Ok(conta);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ViaCepEndereco>> ObterTodosAsync()
        {
            try
            {
                var listaContas = await _contaService.ObterTodosAsync();

                return Ok(listaContas);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ViaCepEndereco>> ObterAsync([FromRoute] int id)
        {
            try
            {
                var conta = await _contaService.ObterPorIDAsync(id);

                return Ok(conta);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<ViaCepEndereco>> AtualizarAsync([FromBody] Conta conta)
        {
            try
            {
                await _contaService.AtualizarAsync(conta);

                return Ok(conta);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ViaCepEndereco>> ExcluirAsync([FromRoute] int id)
        {
            try
            {
                await _contaService.ExcluirAsync(id);

                return Ok();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}