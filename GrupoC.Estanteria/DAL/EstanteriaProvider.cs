using GrupoC.Estanteria.Models;

namespace GrupoC.Estanteria.DAL
{
    public class EstanteriaProvider : IEstanteriaProvider
    {
        private List<Estanterias> estanterias = new ();
        public EstanteriaProvider()
        {
            estanterias.Add(new Estanterias() { Id = "1", Name = "Estanteria Principal", Capacidad = 5,
                Productos = new List<EstanteriaItem>()
                {
                    new EstanteriaItem() { EstanteriaId = "1", Id = 1, ProductoId = "1", Cantidad = 2},
                    new EstanteriaItem() { EstanteriaId = "1", Id = 2, ProductoId = "3", Cantidad = 1},
                    new EstanteriaItem() { EstanteriaId = "1", Id = 3, ProductoId = "2", Cantidad = 1}
                }
            });
            estanterias.Add(new Estanterias() { Id = "2", Name = "Estanteria Secundaria", Capacidad = 15,
                Productos = new List<EstanteriaItem>()
                {
                    new EstanteriaItem() { EstanteriaId = "2", Id = 1, ProductoId = "1", Cantidad = 2},
                    new EstanteriaItem() { EstanteriaId = "2", Id = 2, ProductoId = "3", Cantidad = 1},
                    new EstanteriaItem() { EstanteriaId = "2", Id = 3, ProductoId = "2", Cantidad = 1}
                }
            });
            estanterias.Add(new Estanterias() { Id = "3", Name = "Estanteria Terciaria", Capacidad = 20,
                Productos = new List<EstanteriaItem>()
                {
                    new EstanteriaItem() { EstanteriaId = "3", Id = 1, ProductoId = "1", Cantidad = 2},
                    new EstanteriaItem() { EstanteriaId = "3", Id = 2, ProductoId = "3", Cantidad = 1},
                    new EstanteriaItem() { EstanteriaId = "3", Id = 3, ProductoId = "2", Cantidad = 1}
                }
            });
            estanterias.Add(new Estanterias() { Id = "4", Name = "Cuarta Estanteria", Capacidad = 25,
                Productos = new List<EstanteriaItem>()
                {
                    new EstanteriaItem() { EstanteriaId = "4", Id = 1, ProductoId = "1", Cantidad = 2},
                    new EstanteriaItem() { EstanteriaId = "4", Id = 2, ProductoId = "3", Cantidad = 1},
                    new EstanteriaItem() { EstanteriaId = "4", Id = 3, ProductoId = "2", Cantidad = 1}
                }
            });
        }
        public async Task<Estanterias> GetAsnyc(string id)
        {
            var customer = estanterias.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(customer);
        }
    }
}
