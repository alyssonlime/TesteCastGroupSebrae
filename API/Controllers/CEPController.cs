using API.Interface.Service;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CEPController : ControllerBase
    {
        private readonly ILogger<CEPController> _logger;
        private readonly ICEPService _cepService;

        public CEPController(ILogger<CEPController> logger,
            ICEPService cepService)
        {
            _logger = logger;
            _cepService = cepService;
        }

        [HttpGet]
        [Route("{cep}")]
        public async Task<ActionResult<ViaCepEndereco>> ConsultarAsync([FromRoute] string cep)
        {
            try
            {
                var endereco = await _cepService.ConsultarAsync(cep);

                return Ok(endereco);
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