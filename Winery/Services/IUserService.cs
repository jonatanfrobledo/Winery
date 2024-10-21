using Winery.Dtos;
using Winery.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Winery.Services
{
    public interface IUserService
    {
        Task<User?> AuthenticateUser(string username, string password);
        Task<List<UserDto>> GetAllUsers();
        Task RegisterUser(UserDto user);
        Task DeleteUser(int userId);
    }
}