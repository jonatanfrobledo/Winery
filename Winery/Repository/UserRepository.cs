using Winery.Entities;

namespace Winery.Repository
{
    public class UserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Test",
                    Password = "testing"
                },
                new User
                {
                    Id = 2,
                    Username = "Jonatan",
                    Password = "jonatan"
                }
            };
        }
        public List<User> GetUsers() => _users;


        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
