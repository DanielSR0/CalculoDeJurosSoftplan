using System.Threading.Tasks;

namespace CalculoDeJuros.Negocio
{
    /// <summary>
    /// Serviço para cálculos de juros.
    /// </summary>
    public interface IServicoDeCalculoJuros
    {
        /// <summary>
        /// Calcula os juros com base em um valor inicial, para o tempo determinado.
        /// </summary>
        /// <param name="valorInicial">Valor inicial para a base do cálculo.</param>
        /// <param name="meses">Número de meses para calcular os juros.</param>
        /// <returns>Valor dos juros a ser aplicado, com 2 casas decimais.</returns>
        public Task<double> CalcularJuros(double valorInicial, int meses);
    }
}