using System;
using Winery.Entities;

namespace Winery.Dtos
{
    public class CreateCataDto
    {
        public string Nombre { get; set; }
        public List<WineDto> Vinos { get; set; }
        public List<InvitadoDto> Invitados { get; set; }
    }
}
