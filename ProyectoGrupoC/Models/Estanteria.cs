namespace GrupoC.AlbaranDeEntrega.Models
{
    public class Estanteria
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacidad { get; set; }
        public List<EstanteriaItem> Productos { get; set; }
       
    }
}
