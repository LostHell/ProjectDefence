using MODELS_PROJECT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness2You.Services
{
    public interface IUsersService
    {
        string LoginUser(string username, string password);

        void Register(string username, string email, string password);

        bool ExistsUser(string username);
    }
}
