namespace Fitness2You.Web.ViewModels.User
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UserInputViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public IdentityUserRole<string> Role { get; set; }
    }
}
