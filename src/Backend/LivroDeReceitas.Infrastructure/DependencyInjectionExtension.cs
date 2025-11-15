using FluentMigrator.Runner;
using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Domain.Repositories.Usuario;
using LivroDeReceitas.Infrastructure.DataAcess;
using LivroDeReceitas.Infrastructure.DataAcess.Repositories;
using LivroDeReceitas.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LivroDeReceitas.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddFluentMigrator(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddDbContext<LivroDeReceitasDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUserWriteOnlyRepository, UsuarioRepository>();
            services.AddScoped<IUserReadOnlyRepository, UsuarioRepository>();
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(opt =>
            {
                opt
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("LivroDeReceitas.Infrastructure")).For.All();
            });
        }
    }
}
