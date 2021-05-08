using Microsoft.Extensions.Configuration;
using Refit;
using System.IO;

namespace Comum
{
    /// <summary>
    /// Factory para criação de clients API com Refit.
    /// </summary>
    public sealed class ComunicacaoAPIFactory
    {
        private const string _appSettings = "appsettings.json";

        /// <summary>
        /// Obtém um client de API do Refit, utilizando como URL base configuração existente no arquivo "appsettings.json".
        /// </summary>
        /// <typeparam name="T">Interface Refit para a criação do client API.</typeparam>
        /// <param name="nomeConfigUrl">Nome da seção no arquivo "appsettings.json" que contém a URL para ser utilizada como base para a criação do client API.</param>
        public static T ObterComunicacaoComApi<T>(string nomeConfigUrl)
        {
            var diretorio = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(diretorio)
                .AddJsonFile(_appSettings);

            var config = builder.Build();

            var url = config.GetSection(nomeConfigUrl).Value;

            var comunicacaoApi = RestService.For<T>(url);

            return comunicacaoApi;
        }
    }
}