using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class UserMigration : Migration
    {
        public override void Up()
        {
            Create.Table("User")
               .WithColumn("UserId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Login").AsString(50).NotNullable()
               .WithColumn("Name").AsString(50).NotNullable()
               .WithColumn("Mail").AsString(50).NotNullable()
               .WithColumn("CellPhone").AsString(50).Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

               Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin"));
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}