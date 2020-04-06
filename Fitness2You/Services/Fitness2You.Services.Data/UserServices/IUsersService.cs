namespace Fitness2You.Services.Data.UserServices
{
    using System.Threading.Tasks;

    public interface IUsersService
    {
        bool UsernameExists(string username);

        bool EmailExists(string email);

        Task AddUserInRole(string id);
    }
}
