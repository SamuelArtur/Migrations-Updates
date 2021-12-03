using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class UserCredentialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("UserCredential")
                .WithColumn("UserCredentialId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Password").AsString(150).NotNullable()
                .WithColumn("Salt").AsString(36)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("UserCredential").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("UserCredential").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("UserCredential").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserCredentialByUserId"));
        }

        public override void Down()
        {
            Delete.Table("UserCredential");
        }
    }
}