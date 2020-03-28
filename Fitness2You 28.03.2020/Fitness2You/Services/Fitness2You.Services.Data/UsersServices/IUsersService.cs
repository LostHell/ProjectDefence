﻿namespace Fitness2You.Services.Data.UsersService
{
    using System.Threading.Tasks;

    public interface IUsersService
    {
        bool UsernameExists(string username);

        bool EmailExists(string email);

        Task ChangePassword(string username, string oldPassword, string newPassword);

        Task Register(string username, string email, string phoneNumber, string password);

        Task Login(string username, string password);

        Task Logout();
    }
}
