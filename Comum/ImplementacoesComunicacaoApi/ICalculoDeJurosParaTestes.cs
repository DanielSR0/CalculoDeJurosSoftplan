using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    /// <summary>
    /// Interface Refit para testes de erros da API "CalculoDeJuros".
    /// </summary>
    public interface ICalculoDeJurosParaTestes
    {
        /// <summary>
        /// Método GET para realizar a chamada para o endpoint "/calculaJuros" sem informar o número de meses.
        /// </summary>
        [Get("/calculaJuros")]
        public Task<ApiResponse<double>> GetCalculaJuros(double valorInicial);

        /// <summary>
        /// Método GET criado para testar uma chamada para o endpoint "/calculaJuros" sem informar o valor inicial.
        /// </summary>
        [Get("/calculaJuros")]
        public Task<ApiResponse<double>> GetCalculaJuros(int meses);

        /// <summary>
        /// Método GET criado para testar uma chamada para um endpoint inexistente.
        /// </summary>
        [Get("/naoEncontrado")]
        public Task<ApiResponse<double>> NaoEncontrado();
    }
}