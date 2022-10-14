using GrupoC.AlbaranDeEntrega.Models;

namespace GrupoC.AlbaranDeEntrega.Interfaces
{
    public interface IEstanteriaService
    {
        Task<Estanteria> GetAsync(string estanteriaId);
    }
}
