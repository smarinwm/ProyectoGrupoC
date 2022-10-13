using GrupoC.AlbaranDeEntrega.Models;
using Newtonsoft.Json;

namespace GrupoC.AlbaranDeEntrega.Services
{
    public class EstanteriaService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EstanteriaService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Estanteria>> GetAsync(string estanteriaId)
        {
            var client = httpClientFactory.CreateClient("estanteriasService");

            var response = await client.GetAsync(estanteriaId);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<ICollection<Estanteria>>(content);

                return orders;
            }

            return null;
        }
    }
}
