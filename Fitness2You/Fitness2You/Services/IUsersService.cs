using System.Threading.Tasks;

namespace Fitness2You.Services
{
    public interface IUsersService
    {
        bool UsernameExists(string username);

        bool EmailExists(string email);

        Task Register(string username, string email, string password);

        Task Login(string username, string password);

        Task Logout();
    }
}
