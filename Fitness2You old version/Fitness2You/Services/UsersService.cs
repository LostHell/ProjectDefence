using Fitness2You.Data;
using MODELS_PROJECT.Data;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fitness2You.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool ExistsUser(string username)
        {
            return db.Users.Any(x => x.Username == username);
        }

        public string LoginUser(string username, string password)
        {
            var hashPassword = this.Hash(password);
            var user = this.db.Users.FirstOrDefault(
                u => u.Username == username && u.Password == hashPassword);
            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                RoleId = 1,
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Date = DateTime.UtcNow,
                Salt = this.Hash(2 + password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
