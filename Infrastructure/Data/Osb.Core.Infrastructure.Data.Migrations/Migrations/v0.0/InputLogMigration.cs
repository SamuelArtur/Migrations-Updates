using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    
    public class InputLogMigration : Migration
    {
        public override void Up()
        {
             Create.Table("InputLog")
                .WithColumn("InputLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Message").AsString(100).NotNullable()
                .WithColumn("LogDate").AsDate().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable();

              Create.ForeignKey()
              .FromTable("InputLog").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("InputLog").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("InputLog");
        }
    }
}