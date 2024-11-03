using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;

namespace Winery.Services
{
    public class CataService : ICataService
    {
        private readonly CataRepository _cataRepository;
        private readonly WineRepository _wineRepository;

        public CataService (CataRepository cataRepository, WineRepository wineRepository)
        {
            _cataRepository = cataRepository;
            _wineRepository = wineRepository;
        }
        public Cata CreateCata (CreateCataDto cataDto)
        {
            var vinos = _wineRepository.GetWinesByIds(cataDto.VinosIds);
            var cata = new Cata
            {
                Nombre = cataDto.Nombre,
                Fecha = cataDto.Fecha,
                Vinos = vinos.ToList(),
                Invitados = cataDto.Invitados
            };
            return _cataRepository.AddCata(cata);
        }
    }
}
