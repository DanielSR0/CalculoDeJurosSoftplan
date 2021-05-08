using CalculoDeJuros.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CalculoDeJuros.Controllers
{
    [ApiController]
    [Route("/calculaJuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;
        private readonly IServicoDeCalculoJuros _servicoDeCalculoJuros;

        public CalculaJurosController(
            ILogger<CalculaJurosController> logger,
            IServicoDeCalculoJuros servicoDeCalculoJuros)
        {
            _logger = logger;
            _servicoDeCalculoJuros = servicoDeCalculoJuros;
        }

        [HttpGet]
        public async Task<double> Get(double valorInicial, int meses)
        {
            var resultado = await _servicoDeCalculoJuros.CalcularJuros(valorInicial, meses);

            return resultado;
        }
    }
}