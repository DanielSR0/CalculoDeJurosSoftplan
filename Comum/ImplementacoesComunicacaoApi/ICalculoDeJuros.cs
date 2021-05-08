using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    /// <summary>
    /// Interface Refit para comunicação com a API "CalculoDeJuros".
    /// </summary>
    public interface ICalculoDeJuros
    {
        /// <summary>
        /// Método GET para realizar a chamada para o endpoint "/calculaJuros".
        /// </summary>
        [Get("/calculaJuros")]
        public Task<ApiResponse<double>> GetCalculaJuros(double valorInicial, int meses);

        /// <summary>
        /// Método GET para realizar a chamada para o endpoint "/showMeTheCode".
        /// </summary>
        [Get("/showMeTheCode")]
        public Task<ApiResponse<string>> GetShowMeTheCode();
    }
}