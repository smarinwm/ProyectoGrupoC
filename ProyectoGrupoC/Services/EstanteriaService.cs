using GrupoC.AlbaranDeEntrega.Interfaces;
using GrupoC.AlbaranDeEntrega.Models;
using Newtonsoft.Json;

namespace GrupoC.AlbaranDeEntrega.Services
{
    public class EstanteriaService : IEstanteriaService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EstanteriaService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Estanteria> GetAsync(string estanteriaId)
        {
            var client = httpClientFactory.CreateClient("estanteriasService");

            var response = await client.GetAsync($"api/Estanteria/{estanteriaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<Estanteria>(content);

                return orders;
            }

            return null;
        }
    }
}
