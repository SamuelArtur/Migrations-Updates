using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class UserApplicationMigration : Migration
    {
        public override void Up()
        {
             Create.Table("UserApplication")
                .WithColumn("UserApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ApplicationId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();
        
              Create.ForeignKey()
              .FromTable("UserApplication").ForeignColumn("ApplicationId")
              .ToTable("Application").PrimaryColumn("ApplicationId");
              Create.ForeignKey()
              .FromTable("UserApplication").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");

              Create.ForeignKey()
              .FromTable("UserApplication").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("UserApplication").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("UserApplication");
        }
    }
}