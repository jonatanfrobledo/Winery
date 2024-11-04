namespace Winery.Entities
{
    public class Invitado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CataId { get; set; } 
        public Cata Cata { get; set; }
    }
}
