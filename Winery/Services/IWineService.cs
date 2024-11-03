using Winery.Dtos;
using System.Collections.Generic;

namespace Winery.Services
{
    public interface IWineService
    {
        List<WineDto> GetAllWines();
        WineDto GetWineByName(string name);
        void RegisterWine(WineDto wineDto);
        void AddStock(string name, int quantity);
        List<WineDto> GetWineByVariety(string variety);
    }
}