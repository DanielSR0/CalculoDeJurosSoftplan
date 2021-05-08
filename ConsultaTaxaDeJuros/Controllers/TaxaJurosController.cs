using ConsultaTaxaDeJuros.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsultaTaxaDeJuros.Controllers
{
    [ApiController]
    [Route("/taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ILogger<TaxaJurosController> _logger;
        private readonly IConsultaDeTaxaJuros _consultaDeTaxaJuros;

        public TaxaJurosController(
            ILogger<TaxaJurosController> logger,
            IConsultaDeTaxaJuros consultaDeTaxaJuros)
        {
            _logger = logger;
            _consultaDeTaxaJuros = consultaDeTaxaJuros;
        }

        [HttpGet]
        public async Task<double> Get()
        {
            _logger.LogInformation("Taxa atual de juros sendo consultada.");

            var taxaJuros = await _consultaDeTaxaJuros.BuscarTaxaJuros();

            return taxaJuros;
        }
    }
}