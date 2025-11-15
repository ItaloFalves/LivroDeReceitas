using Microsoft.Extensions.Configuration;

namespace LivroDeReceitas.Infrastructure.Extension
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("Connection")!;

        }
    }
}
