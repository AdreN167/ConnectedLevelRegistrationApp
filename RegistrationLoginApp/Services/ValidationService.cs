using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace RegistrationLoginApp.Services
{
    static class ValidationService
    {
        public static bool PicturesExtension(string path)
        {
            var extensions = new string[] { "png", "jpg", "jpeg" };
            var splitedPath = path.Split('.');

            bool isCorrect = false;

            foreach (var extension in extensions)
            {
                if (splitedPath[splitedPath.Length - 1] == extension)
                {
                    isCorrect = true;
                    break;
                }
            }

            return isCorrect;
        }

        public static bool UniqueLogin(string login, string[] dbLogins)
        {
            foreach (var dbLogin in dbLogins)
            {
                if (login == dbLogin)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CorrectEmail(string email)
        {
            var domains = new string[] { "mail.ru", "inbox.ru", "bk.ru", "list.ru", "internet.ru", "gmail.com" };
            var splitedEmail = email.Split('@');

            if (splitedEmail.Length != 2)
            {
                return false;
            }

            foreach (var domain in domains)
            {
                if (domain == splitedEmail[1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
