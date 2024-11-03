using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Winery.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public User? AuthenticateUser(string username, string password)
        {
            var user = _repository.GetUserByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _repository.GetUsers();
            return users.Select(x => new UserDto
            {
                Username = x.Username
            }).ToList();
        }

        public void RegisterUser(UserDto userDto)
        {
            var existingUser = _repository.GetUserByUsername(userDto.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");
            }

            var user = new User
            {
                Username = userDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            };
            _repository.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _repository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("El usuario no existe.");
            }

            _repository.DeleteUser(userId); 
        }
    }
}
