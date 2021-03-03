using System;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace RegistrationLoginApp.Services
{
    public static class ConfigurationService
    {

        public static IConfigurationRoot Configuration { get; private set; }

        public static void Init()
        {
            if (DbProviderFactories.GetFactory("ConnectedLevelProvider") == null)
            {
                DbProviderFactories.RegisterFactory("ConnectedLevelProvider", SqlClientFactory.Instance);
            }

            if (Configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                Configuration = configurationBuilder.AddJsonFile("appSettings.json").Build();
            }
        }
    }
}
