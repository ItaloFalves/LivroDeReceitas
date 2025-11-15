using FluentMigrator;

namespace LivroDeReceitas.Infrastructure.Migrations.Versions
{
    [Migration(1, "Criar tabelas de usuarios")]
    public class Version01 : VersionBase
    {
        public override void Up()
        {
            CreateTable("usuarios")
                .WithColumn("Nome").AsString(50).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable()
                .WithColumn("Senha").AsString(3000).NotNullable();
            
        }
    }
}
