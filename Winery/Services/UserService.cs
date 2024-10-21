using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;
using BCrypt.Net; // Asegúrate de instalar la biblioteca BCrypt.Net
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winery.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        // Cambiado a Task<User?> para coincidir con la implementación del controlador
        public async Task<User?> AuthenticateUser(string username, string password)
        {
            // Verifica si el usuario existe
            var user = await _repository.GetUserByUsernameAsync(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) // Verifica la contraseña
            {
                return user; // Retorna el usuario si la autenticación es exitosa
            }
            return null; // Retorna null si la autenticación falla
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _repository.GetUsers(); // Usa el método asíncrono
            return users.Select(x => new UserDto
            {
                Username = x.Username,
                // No incluir la contraseña en el DTO
            }).ToList();
        }

        public async Task RegisterUser(UserDto userDto)
        {
            // Verifica si el usuario ya existe
            var existingUser = await _repository.GetUserByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");
            }

            var user = new User
            {
                Username = userDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // Hashea la contraseña antes de guardarla
            };
            await _repository.AddUserAsync(user); // Usa el método asíncrono
        }

        public async Task DeleteUser(int userId)
        {
            await _repository.DeleteUserAsync(userId); // Usa el método asíncrono
        }
    }
}
