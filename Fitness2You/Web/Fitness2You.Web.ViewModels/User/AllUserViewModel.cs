namespace Fitness2You.Web.ViewModels.User
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class AllUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
