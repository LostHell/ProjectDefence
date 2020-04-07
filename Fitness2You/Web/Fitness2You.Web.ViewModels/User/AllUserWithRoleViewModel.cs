namespace Fitness2You.Web.ViewModels.User
{
    using System.Collections.Generic;

    public class AllUserWithRoleViewModel
    {
        public IList<UserInputViewModel> User { get; set; }

        public IList<UserRoleInputViewModel> UserRole { get; set; }

        public IList<RoleInputViewModel> Role { get; set; }
    }
}
