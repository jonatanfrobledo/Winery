using System;

namespace Winery.Dtos
{
    public class CreateCataDto
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<int> VinosIds { get; set; }
        public List<string> Invitados { get; set; }
    }
}
