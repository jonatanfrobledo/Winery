using Winery.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Winery.Repository
{
    public class WineRepository
    {
        private readonly WineryContext _context;

        public WineRepository(WineryContext context)
        {
            _context = context;
        }

        public List<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }

        public Wine? GetWineByName(string name)
        {
            return _context.Wines
                .FirstOrDefault(w => w.Name.ToLower() == name.ToLower());
        }

        public void AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges(); 
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
                _context.SaveChanges(); 
            }
        }
    }
}
