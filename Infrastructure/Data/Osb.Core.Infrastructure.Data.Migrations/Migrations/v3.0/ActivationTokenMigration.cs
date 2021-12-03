using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V03
{
    public class ActivationTokenMigration : Migration
    {
        public override void Up()
        {
            Create.Table("ActivationToken")
               .WithColumn("ActivationTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("Code").AsString(50).NotNullable().Nullable()
               .WithColumn("ExpirationDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
            .FromTable("ActivationToken").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivationTokenByCode"));
        }

        public override void Down()
        {
            Delete.Table("ActivationToken");
        }
    }
}