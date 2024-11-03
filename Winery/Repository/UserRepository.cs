using Winery.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Winery.Repository
{
    public class UserRepository
    {
        private readonly WineryContext _context;

        public UserRepository(WineryContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
