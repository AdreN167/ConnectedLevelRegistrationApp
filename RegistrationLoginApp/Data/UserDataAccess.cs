using RegistrationLoginApp.Models;
using System;
using System.Collections.Generic;

namespace RegistrationLoginApp.Data
{
    public class UserDataAccess : DbDataAccess<User>
    {
        public override void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public override void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public override ICollection<User> Select()
        {
            throw new NotImplementedException();
        }

        public User SelectUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public string[] SelectLogins()
        {
            throw new NotImplementedException();
        }

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
