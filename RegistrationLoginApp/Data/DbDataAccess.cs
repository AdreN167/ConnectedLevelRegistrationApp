using System;
using System.Data.Common;
using System.Collections.Generic;
using RegistrationLoginApp.Services;

namespace RegistrationLoginApp.Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("ConnectedLevelProvider");

            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["ConnectedLevelProvider"];
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
        public abstract ICollection<T> Select();

        public void ExecuteTransaction(params DbCommand[] commands)
        {
            using(var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (DbException)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
