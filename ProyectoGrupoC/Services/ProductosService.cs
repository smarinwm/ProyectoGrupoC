using GrupoC.AlbaranDeEntrega.Interfaces;
using GrupoC.AlbaranDeEntrega.Models;
using Newtonsoft.Json;

namespace GrupoC.AlbaranDeEntrega.Services
{
    public class ProductosService : IProductoService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductosService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<Producto> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productosService");

            var response = await client.GetAsync($"api/Producto/{id}");
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
