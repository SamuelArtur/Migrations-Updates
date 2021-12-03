using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    public class OutputLogMigration : Migration
    {
        public override void Up()
        {
            Create.Table("OutputLog")
               .WithColumn("OutputLogId").AsInt64().NotNullable().PrimaryKey()
               .WithColumn("Response").AsString().NotNullable()
               .WithColumn("LogDate").AsDateTime().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("OutputLog").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("OutputLog").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("OutputLog");
        }
    }
}