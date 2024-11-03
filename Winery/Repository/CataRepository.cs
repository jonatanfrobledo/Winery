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
    }
}