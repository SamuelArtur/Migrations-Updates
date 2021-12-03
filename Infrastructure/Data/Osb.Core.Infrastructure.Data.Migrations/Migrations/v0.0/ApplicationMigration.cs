using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class ApplicationMigration : Migration
    {
        public override void Up()
        {
             Create.Table("Application")
                .WithColumn("ApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("WhitelabelName").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();
        
              Create.ForeignKey()
              .FromTable("Application").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("Application").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("Application");
        }
    }
}