using RegistrationLoginApp.Data;

namespace RegistrationLoginApp.Services
{
    public static class LoginService
    {
        public static bool Login(string login, string password)
        {
            var userDataAccess = new UserDataAccess();
            var user = userDataAccess.SelectUserByLogin(login);

            if (user == null)
            {
                return false;
            }

            if (!PasswordService.VerifyHashedPassword(user.Password, password))
            {
                return false;
            }

            return true;
        }
    }
}
