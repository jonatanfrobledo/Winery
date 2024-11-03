using Winery.Dtos;
using Winery.Entities;
using System.Collections.Generic;

namespace Winery.Services
{
    public interface IUserService
    {
        User? AuthenticateUser(string username, string password); 
        List<UserDto> GetAllUsers();
        void RegisterUser(UserDto user); 
        void DeleteUser(int userId); 
    }
}
