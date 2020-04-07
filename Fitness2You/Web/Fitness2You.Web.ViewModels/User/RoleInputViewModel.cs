namespace Fitness2You.Web.ViewModels.User
{
    using Fitness2You.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class RoleInputViewModel : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IdentityUserRole<string> Role { get; set; }
    }
}
