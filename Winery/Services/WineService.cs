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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));
            }

       
            var wine = _repository.GetWineByName(name);
            if (wine == null)
            {
                return null; 
            }

          
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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del vino no puede estar vacío.", nameof(name));
            }

            var wine = _repository.GetWineByName(name);
            if (wine != null)
            {
                wine.Stock += quantity;
                _repository.UpdateWine(wine);
            }
            else
            {
                throw new Exception($"El vino '{name}' no existe en el inventario.");
            }
        }

        public List<WineDto> GetWineByVariety(string variety)
        {
            if (string.IsNullOrWhiteSpace(variety))
            {
                throw new ArgumentException("La variedad no puede estar vacía.", nameof(variety));
            }

            var wines = _repository.GetWines()
                .Where(w => w.Variety.Equals(variety, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return wines.Select(w => new WineDto
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }
    }
}
