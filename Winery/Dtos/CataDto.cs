namespace Winery.Dtos
{
    public class CataDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List <WineDto> Vinos { get; set; } = new List<WineDto> ();
        public List <InvitadoDto> Invitados { get; set; } = new List<InvitadoDto> ();
    }
}
