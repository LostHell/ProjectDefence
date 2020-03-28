namespace Fitness2You.Web.ViewModels.F2Y
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class UsersViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
