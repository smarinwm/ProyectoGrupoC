using Grupo5.Producto.Models;
namespace Grupo5.Producto.DAL
{
    public interface IProductoRepository
    {
        Task<Productos> GetAsync(string id);
    }
}
