using GrupoC.Estanteria.Models;

namespace GrupoC.Estanteria.DAL
{
    public interface IEstanteriaProvider
    {
        Task<Estanterias> GetAsnyc(string id);
    }
}
