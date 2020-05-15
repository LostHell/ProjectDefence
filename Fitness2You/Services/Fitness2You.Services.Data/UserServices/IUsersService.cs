namespace Fitness2You.Services.Data.UserServices
{
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<bool> UsernameExists(string username);

        Task<bool> EmailExists(string email);

        Task AddUserInRole(string id);
    }
}
