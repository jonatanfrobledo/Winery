using Winery.Dtos;

namespace Winery.Services
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();

        void RegisterUser(UserDto user);


    }
}
