using Fitness2You.Data;
using Fitness2You.Models.Enums;
using MODELS_PROJECT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fitness2You.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool EmailExists(string email)
        {
            return db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var hashPass = Hash(password);
            var user = db.Users
                .FirstOrDefault(x => x.Username == username && x.Password == hashPass);
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public string GetUsername(string id)
        {
            var username = db.Users.Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();

            return username;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = Hash(password),
                Salt = Hash(password),
                Date = DateTime.UtcNow,
                Role = Enum.Parse<Role>("User"),
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
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
