using Winery.Dtos;
using Winery.Entities;

namespace Winery.Services
{
    public interface ICataService
    {
        Cata CreateCata(CreateCataDto cataDto);
    }
}
