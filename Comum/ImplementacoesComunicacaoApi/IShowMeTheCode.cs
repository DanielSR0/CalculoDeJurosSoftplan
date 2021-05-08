using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    public interface IShowMeTheCode : IComunicacaoApi
    {
        [Get("/showMeTheCode")]
        Task<string> Get();
    }
}