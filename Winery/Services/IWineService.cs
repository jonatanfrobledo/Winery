using System.Runtime.CompilerServices;
using Winery.Dtos;

namespace Winery.Services
{
    public interface IWineService
    {
        List<WineDto> GetAllWines();
        WineDto GetWineByName(string name);

        void RegisterWine(WineDto wineDto);

        void AddStock(string name, int quantify);
    }
}
