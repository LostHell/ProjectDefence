namespace Fitness2You.Web.ViewModels.Account
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class UserClassInputViewModel : IMapFrom<UserClass>
    {
        public Class Class { get; set; }

        public ApplicationUser User { get; set; }
    }
}
