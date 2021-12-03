using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(17, "Create table AccountLog")]
    public class AccountLogMigration : Migration
    {
        public override void Up()
        {
            Create.Table("AccountLog")
               .WithColumn("AccountLogId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Login").AsString()
               .WithColumn("LogDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("AccountLog").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("AccountLog").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("AccountLog");
        }
    }
}