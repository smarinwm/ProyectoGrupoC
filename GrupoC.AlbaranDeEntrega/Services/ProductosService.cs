using GrupoC.AlbaranDeEntrega.Models;
using Newtonsoft.Json;

namespace GrupoC.AlbaranDeEntrega.Services
{
    public class ProductosService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductosService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<Producto> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productosService");

            var response = await client.GetAsync($"api/productos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Producto>(content);

                return product;
            }
            return null;
        }
    }
}
