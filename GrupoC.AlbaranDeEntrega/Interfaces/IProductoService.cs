using GrupoC.AlbaranDeEntrega.Models;

namespace GrupoC.AlbaranDeEntrega.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> GetAsync(string id);
    }
}
