using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;

namespace Winery.Services
{
    public class WineService : IWineService
    {
        private readonly WineRepository _repository;

        public WineService(WineRepository repository)
        {
            _repository = repository;
        }

        public List<WineDto> GetAllWines()
        {
            var wines = _repository.GetWines();
            return wines.Select(w => new WineDto
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }

        public WineDto GetWineByName(string name)
        {
            var wine = _repository.GetWineByName(name);
            if (wine == null)
                return null;

            return new WineDto
            {
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock
            };
        }

        public void RegisterWine(WineDto wineDto)
        {
            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            _repository.AddWine(wine);
        }
        public void AddStock(string name, int quantity)
        {
            var wine = _repository.GetWineByName(name);
            if (name == null)
            {
                wine.Stock += quantity;
                _repository.UpdateWine(wine);
            }
            else
            {
                throw new Exception($"El vino {name} no existe en el inventario");
            }
        }
    }
}