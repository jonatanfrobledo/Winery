using System.Collections.Generic; // Asegúrate de tener este espacio de nombres

namespace Winery.Entities
{
    public class Cata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>(); // Inicializa la lista
        public List<Guest> Guests { get; set; } = new List<Guest>(); // Cambiado a una lista de Guest
    }
}