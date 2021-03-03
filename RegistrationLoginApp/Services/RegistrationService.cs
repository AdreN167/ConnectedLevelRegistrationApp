using RegistrationLoginApp.Data;
using RegistrationLoginApp.Models;

namespace RegistrationLoginApp.Services
{
    public static class RegistrationService
    {
        public static bool Registration(string login, string password, string repitedPassword)
        {
            var userDataAccess = new UserDataAccess();

            var logins = userDataAccess.SelectLogins();

            if (!ValidationService.UniqueLogin(login, logins))
            {
                return false;
            }

            if (password != repitedPassword)
            {
                return false;
            }

            userDataAccess.Insert(new User { Login = login, Password = PasswordService.HashPassword(password) });

            return true;
        }
    }
}
