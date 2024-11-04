using Microsoft.EntityFrameworkCore;
using Winery.Entities;

namespace Winery.Repository
{
    public class CataRepository
    {
        private readonly WineryContext _context;

        public CataRepository(WineryContext context)
        {
            _context = context;
        }

        public Cata AddCata(Cata cata)
        {
            _context.Catas.Add(cata);
            _context.SaveChanges();
            return cata;
        }
        public Cata? GetById(int id)
        {
            return _context.Catas
                .Include(c => c.Vinos)
                .Include(c => c.Invitados)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}