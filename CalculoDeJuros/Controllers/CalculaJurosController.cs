using CalculoDeJuros.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.Controllers
{
    /// <summary>
    /// API para cálculo de juros.
    /// </summary>
    [ApiController]
    [Route("/calculaJuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;
        private readonly IServicoDeCalculoJuros _servicoDeCalculoJuros;

        /// <summary>
        /// Construtor.
        /// </summary>
        public CalculaJurosController(
            ILogger<CalculaJurosController> logger,
            IServicoDeCalculoJuros servicoDeCalculoJuros)
        {
            _logger = logger;
            _servicoDeCalculoJuros = servicoDeCalculoJuros;
        }

        /// <summary>
        /// Cálculo dos juros com base em um valor inicial, para o tempo determinado.
        /// </summary>
        /// <param name="valorInicial">Valor inicial para a base do cálculo.</param>
        /// <param name="meses">Número de meses para calcular os juros.</param>
        /// <returns>Valor dos juros a ser aplicado, com 2 casas decimais.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<double>> Get(double valorInicial, int meses)
        {
            _logger.LogInformation(
                "Solicitado cálculo de juros sobre o valor inicial {valorInicial} ao longo de {meses} meses.",
                valorInicial.ToString("N2"),
                meses.ToString());

            try
            {
                var resultado = await _servicoDeCalculoJuros.CalcularJuros(valorInicial, meses);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest($"{ex.Message}");
            }
        }
    }
}