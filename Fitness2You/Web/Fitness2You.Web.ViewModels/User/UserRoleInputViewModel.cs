namespace Fitness2You.Web.ViewModels.User
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UserRoleInputViewModel : IMapFrom<IdentityUserRole<string>>
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }
    }
}
