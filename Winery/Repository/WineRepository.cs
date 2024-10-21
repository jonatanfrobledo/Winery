using Microsoft.EntityFrameworkCore;
using Winery.Entities;

namespace Winery.Repository
{
    public class WineRepository
    {
        private readonly WineryContext _context;

        public WineRepository()
        {
            // Configura las opciones para el contexto
            var optionsBuilder = new DbContextOptionsBuilder<WineryContext>();
            optionsBuilder.UseSqlite("Data Source=winery.db");

            _context = new WineryContext(optionsBuilder.Options);
            _context.Database.EnsureCreated(); // Asegura que la base de datos se cree si no existe
        }

        public List<Wine> GetWines() => _context.Wines.ToList();

        public Wine GetWineByName(string name) => _context.Wines
            .FirstOrDefault(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        public void UpdateWine(Wine wine)
        {
            var existingWine = GetWineByName(wine.Name);
            if (existingWine != null)
            {
                existingWine.Variety = wine.Variety;
                existingWine.Year = wine.Year;
                existingWine.Region = wine.Region;
                existingWine.Stock = wine.Stock;
                _context.SaveChanges(); // Guarda los cambios en la base de datos
            }
        }
    }
}
