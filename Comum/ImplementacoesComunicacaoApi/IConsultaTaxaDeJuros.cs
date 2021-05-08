using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    /// <summary>
    /// Interface Refit para comunicação com a API "ConsultaTaxaDeJuros".
    /// </summary>
    public interface IConsultaTaxaDeJuros
    {
        /// <summary>
        /// Método GET para realizar a chamada para o endpoint "/taxaJuros".
        /// </summary>
        [Get("/taxaJuros")]
        public Task<ApiResponse<double>> Get();
    }
}