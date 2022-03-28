using Microsoft.Extensions.Options;
using RS.Calculo.Api.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RS.Calculo.Api.Application.Queries
{
    public class TaxaQueryHandler : IQueryHandler<TaxaQuery, decimal>
    {
        private readonly HttpClient _httpClient;

        public TaxaQueryHandler(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.TaxaUrl);
        }

        public async Task<decimal> ExecuteAsync(TaxaQuery query)
        {
            try
            {
                var response = await _httpClient.GetAsync("Taxa");
                return await response.Content.ReadFromJsonAsync<decimal>();
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("Não foi possível se conectar ao servidor\n");
            }
            catch (HttpRequestException ex)
            {
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new Exception("Parâmetro mal formatado ou inválido \n");

                    // Outros tratamentos de exceção.
                    default:
                        throw new Exception("Não foi possível se conectar ao servidor \n");
                }
            }
        }
    }
}
