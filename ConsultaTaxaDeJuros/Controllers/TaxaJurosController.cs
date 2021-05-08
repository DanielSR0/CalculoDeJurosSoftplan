using ConsultaTaxaDeJuros.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public double Get()
        {
            var taxaJuros = _consultaDeTaxaJuros.BuscarTaxaJuros();

            return taxaJuros;
        }
    }
}
