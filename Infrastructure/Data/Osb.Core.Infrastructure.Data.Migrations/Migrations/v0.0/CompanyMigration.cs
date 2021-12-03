using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class CompanyMigration : Migration
    {
        public override void Up()
        {
             Create.Table("Company")
                .WithColumn("CompanyId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

              Create.ForeignKey()
              .FromTable("Company").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("Company").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("Company");
        }
    }
}