using Dapper;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace LivroDeReceitas.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDataCreated(connectionString);
            MigrationDataBase(serviceProvider);
        }

        private static void EnsureDataCreated(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dataBaseName = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", dataBaseName);

            var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (!records.Any())
            {
                dbConnection.Execute($"CREATE DATABASE {dataBaseName}");
            }
        }

        private static void MigrationDataBase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}
