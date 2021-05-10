using System.Threading.Tasks;

namespace CalculoDeJuros.Negocio
{
    /// <summary>
    /// Serviço para realizar consulta à taxas de juros.
    /// </summary>
    public interface IServicoDeConsultaTaxaJuros
    {
        /// <summary>
        /// Obtém a taxa de juros atual.
        /// </summary>
        public Task<double> ObterTaxaAtual();
    }
}