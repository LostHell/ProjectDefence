using Fitness2You.Data;
using Fitness2You.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MODELS_PROJECT.Data;
using System;
using System.Threading.Tasks;

namespace Fitness2You.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<User>>();
            this.roleManager = serviceProvider.GetService<RoleManager<Role>>();
            this.dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            await SeedUsersAsync();
            await SeedRolesAsync();
            await SeedUserToRolesAsync();
        }

        private async Task SeedUserToRolesAsync()
        {
            var user = await userManager.FindByNameAsync("deibadei");
            var role = await roleManager.FindByNameAsync("Admin");

            //var exist = dbContext.Users.Any(x => x.Role.Name == role.Name && x.Role.Id == role.Id);

            //if (exist)
            //{
            //    return;
            //}

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");
            if (role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new Role
            {
                Name = "Admin"
            });
        }

        private async Task SeedUsersAsync()
        {
            var user = await userManager.FindByNameAsync("deibadei");
            if (user != null)
            {
                return;
            }
           var result = await userManager.CreateAsync(new User
            {
                Username = "deibadei",
                Email = "deibadei@gmail.com",
                Password = "qwerty12",
                Date = DateTime.UtcNow,
                Salt = "2+qwerty12",
            });
        }
    }
}
