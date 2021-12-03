using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class UserCredentialLogMigration : Migration
    {
        public override void Up()
        {
             Create.Table("UserCredentialLog")
                .WithColumn("UserCredentialLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Login").AsString(50).NotNullable()
                .WithColumn("LogDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable();

              Create.ForeignKey()
              .FromTable("UserCredentialLog").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("UserCredentialLog").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");

              Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog"));
        }

        public override void Down()
        {
            Delete.Table("UserCredentialLog");
        }
    }
}