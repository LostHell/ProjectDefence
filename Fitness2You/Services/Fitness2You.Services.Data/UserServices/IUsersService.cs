namespace Fitness2You.Services.Data.UserServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.User;

    public interface IUsersService
    {
        bool UsernameExists(string username);

        bool EmailExists(string email);

        Task AddUserInRole(string id);
    }
}
