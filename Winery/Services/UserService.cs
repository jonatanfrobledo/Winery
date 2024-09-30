using Winery.Dtos;
using Winery.Entities;
using Winery.Repository;

namespace Winery.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _repository.GetUsers();
            return users.Select(x => new UserDto
            {
                Username = x.Username,
                Password = x.Password,
            }).ToList();
        }
        public void RegisterUser (UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
            };
            _repository.AddUser(user);
        }
    }
}
