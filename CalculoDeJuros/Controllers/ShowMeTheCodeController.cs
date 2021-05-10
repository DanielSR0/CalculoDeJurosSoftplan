using Microsoft.AspNetCore.Mvc;

namespace CalculoDeJuros.Controllers
{
    /// <summary>
    /// API para consulta da URL do código fonte no github.
    /// </summary>
    [ApiController]
    [Route("/showMeTheCode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Obter URL do código fonte no github.
        /// </summary>
        [HttpGet]
        public string Get()
        {
            var urlGit = "https://github.com/DanielSR0/CalculoDeJurosSoftplan";

            return urlGit;
        }
    }
}