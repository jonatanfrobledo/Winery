using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;

namespace Winery.Services
{
    public class CataService : ICataService
    {
        private readonly CataRepository _cataRepository;
        private readonly WineRepository _wineRepository;

        public CataService(CataRepository cataRepository, WineRepository wineRepository)
        {
            _cataRepository = cataRepository;
            _wineRepository = wineRepository;
        }
        public Cata CreateCata(CreateCataDto cataDto)
        {
            var nuevaCata = new Cata
            {
                Nombre = cataDto.Nombre,
                Fecha = DateTime.Now,
                Vinos = new List<Wine>(),
                Invitados = new List<Guest>(),
            };
            return _cataRepository.AddCata(nuevaCata);
        }
        public CataDto? GetCataById(int id)
        {
            var cata = _cataRepository.GetById(id);
            if (cata == null) return null;
            var cataDto = new CataDto
            {
                Id = cata.Id,
                Nombre = cata.Nombre,
                Fecha = cata.Fecha,
                Vinos = cata.Vinos.Select(v => new WineDto
                {
                    Name = v.Name,
                    Variety = v.Variety,
                    Year = v.Year,
                    Region = v.Region,
                    Stock = v.Stock,
                }).ToList(),
                Invitados = cata.Invitados.Select(i => new InvitadoDto
                {
                    Nombre = i.Nombre,
                    CataId = i.CataId
                }).ToList()
            };
            return cataDto;
        }
    }
}
