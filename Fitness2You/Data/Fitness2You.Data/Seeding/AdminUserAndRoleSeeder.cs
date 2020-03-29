namespace Fitness2You.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminUserAndRoleSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ApplicationDbContext db;

        public AdminUserAndRoleSeeder(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            this.userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            this.db = db;
        }

        public async Task SeedDataAsync()
        {
            await this.SeedUsersAsync();
            await this.SeedRolesAsync();
            await this.SeedUserToRolesAsync();
        }

        private async Task SeedUserToRolesAsync()
        {
            var user = await this.userManager.FindByNameAsync("Administrator");
            var role = await this.roleManager.FindByNameAsync("Admin");

            var existUser = this.db.UserRoles.Any(x => x.UserId == user.Id);
            var existRole = this.db.UserRoles.Any(x => x.RoleId == role.Id);

            if (existUser == false)
            {
                var userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };
                await this.db.UserRoles.AddAsync(userRole);
                await this.db.SaveChangesAsync();
            }
        }

        private async Task SeedRolesAsync()
        {
            var adminRole = await this.roleManager.FindByNameAsync("Admin");
            var userRole = await this.roleManager.FindByNameAsync("User");

            if (adminRole == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                });
            }

            if (userRole == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
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
            var user = await this.userManager.FindByNameAsync("Administrator");
            if (user != null)
            {
                return;
            }

            var newUser = new ApplicationUser
            {
                UserName = "Administrator",
                Email = "admin@admin.com",
            };

            var password = "administrator";

            var result = await this.userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                return;
            }
        }
    }
}
