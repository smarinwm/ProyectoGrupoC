using Grupo5.Producto.Models;
namespace Grupo5.Producto.DAL
{
    public class ProductoRepository:IProductoRepository
    {
        private List<Productos> repo = new List<Productos>();

        public ProductoRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                repo.Add(new Productos()
                {
                    Id = (i + 1).ToString(),
                    Nombre = $"Producto {i + 1}",
                    Precio = (double)i * Math.PI
                });
            }
        }
        public Task<Productos> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
