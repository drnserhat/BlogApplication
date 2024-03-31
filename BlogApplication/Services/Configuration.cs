using Microsoft.Extensions.Configuration;
namespace BlogApplication.Services
{
    public class Configuration
    {
        private static IConfigurationRoot _configuration;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("Mssql");
            }
        }

  
    }
}
