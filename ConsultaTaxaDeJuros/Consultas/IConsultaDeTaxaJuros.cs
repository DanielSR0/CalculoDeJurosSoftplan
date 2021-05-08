using System.Threading.Tasks;

namespace ConsultaTaxaDeJuros.Consultas
{
    /// <summary>
    /// Consulta de taxas de juros.
    /// </summary>
    public interface IConsultaDeTaxaJuros
    {
        /// <summary>
        /// Buscar a taxa de juros corrente.
        /// </summary>
        public Task<double> BuscarTaxaJuros();
    }
}