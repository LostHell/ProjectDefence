using Fitness2You.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Fitness2You.Services
{
    public class F2YService : IF2YService
    {
        private readonly ApplicationDbContext db;

        public F2YService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IdentityUser> All()
        {
            var result = db.Users.ToList();
            return result;
        }
    }
}
