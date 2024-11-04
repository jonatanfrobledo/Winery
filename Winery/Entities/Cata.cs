using System.Collections.Generic;

namespace Winery.Entities
{

    public class Cata
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public List<Wine> Vinos { get; set; } = new List<Wine>(); 
        public List<Guest> Invitados { get; set; } = new List<Guest>(); 
        public List<Cata> Catas { get; set; }
    }
}