using Microsoft.AspNetCore.Mvc;

namespace CalculoDeJuros.Controllers
{
    [ApiController]
    [Route("/showMeTheCode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        public ShowMeTheCodeController()
        {
        }

        [HttpGet]
        public string Get()
        {
            var urlGit = "https://github.com/DanielSR0/CalculoDeJurosSoftplan";

            return urlGit;
        }
    }
}