using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace LivroDeReceitas.Infrastructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string tabela)
        {
            return Create.Table(tabela)
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("DataCriacao").AsDate().NotNullable()
               .WithColumn("Ativo").AsBoolean().NotNullable();
        }
    }
}
