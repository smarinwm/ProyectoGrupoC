using GrupoC.AlbaranDeEntrega.Models;

namespace GrupoC.AlbaranDeEntrega.Interfaces
{
    public interface IEstanteriaService
    {
        Task<ICollection<Estanteria>> GetAsync(string estanteriaId);
    }
}
