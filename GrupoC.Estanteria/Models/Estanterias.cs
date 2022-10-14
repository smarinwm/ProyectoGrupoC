namespace GrupoC.Estanteria.Models
{
    public class Estanterias
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacidad { get; set; }
        public List<EstanteriaItem> Productos { get; set; }
    }
}
