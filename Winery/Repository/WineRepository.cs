using Winery.Entities;

namespace Winery.Repository
{
    public class WineRepository
    {
        private readonly List<Wine> _wines;

        public WineRepository()
        {
            _wines = new List<Wine>
            {
                new Wine
                {
                    Id = 1,
                    Name = "Malbec Reserve",
                    Variety = "Malbec",
                    Year = 2018,
                    Region = "Mendoza",
                    Stock = 150
                },
                new Wine
                {
                    Id = 2,
                    Name = "Chardonnay Premium",
                    Variety = "Chardonnay",
                    Year = 2020,
                    Region = "San Juan",
                    Stock = 200
                },
                new Wine
                {
                    Id = 3,
                    Name = "Cabernet Sauvignon Gran Reserva",
                    Variety = "Cabernet Sauvignon",
                    Year = 2017,
                    Region = "La Rioja",
                    Stock = 75
                },
                new Wine
                {
                    Id = 4,
                    Name = "Syrah Clásico",
                    Variety = "Syrah",
                    Year = 2019,
                    Region = "Salta",
                    Stock = 120
                }
            };
        }
        public List<Wine> GetWines() => _wines;
        
        public Wine GetWineByName(string name) => _wines.FirstOrDefault(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void AddWine (Wine wine)
        {
            _wines.Add(wine);
        }
        public void UpdateWine (Wine wine)
        {
            var existingWine = GetWineByName(wine.Name);
            if (existingWine != null)
            {
                existingWine.Variety = wine.Variety;
                existingWine.Year = wine.Year;
                existingWine.Region = wine.Region;
                existingWine.Stock = wine.Stock;  // Actualizamos solo el stock, pero puedes actualizar otros campos si es necesario
            }
        }
    }
}
