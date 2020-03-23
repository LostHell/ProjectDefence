using Fitness2You.Data;
using Fitness2You.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness2You.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext db;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext db)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.db = db;
        }

        public async Task SeedDataAsync()
        {
            await SeedUsersAsync();
            await SeedRolesAsync();
            await SeedUserToRolesAsync();
        }

        private async Task SeedUserToRolesAsync()
        {
            var user = await userManager.FindByNameAsync("Administrator");
            var role = await roleManager.FindByNameAsync("Admin");

            var existUser = db.UserRoles.Any(x => x.UserId == user.Id);
            var existRole = db.UserRoles.Any(x => x.RoleId == role.Id);

            if (existUser == false)
            {
                var userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = role.Id
                };
                await db.UserRoles.AddAsync(userRole);
                await db.SaveChangesAsync();
            }
        }

        private async Task SeedRolesAsync()
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            var userRole = await roleManager.FindByNameAsync("User");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                });
            }
            if (userRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "User",
                });
            }
            else
            {
                return;
            }
        }

        private async Task SeedUsersAsync()
        {
            var user = await userManager.FindByNameAsync("Administrator");
            if (user != null)
            {
                return;
            }

            var newUser = new IdentityUser
            {
                UserName = "Administrator",
                Email = "admin@admin.com",
            };

            var password = "administrator";

            var result = await userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {

            }
        }
    }
}
