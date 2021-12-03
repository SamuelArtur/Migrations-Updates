using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class UserAccountMigration : Migration
    {
        public override void Up()
        {
             Create.Table("UserAccount")
                .WithColumn("UserAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

              Create.ForeignKey()
              .FromTable("UserAccount").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("UserAccount").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("UserAccount").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("UserAccount").ForeignColumn("AccountId")
              .ToTable("Account").PrimaryColumn("AccountId");
        }

        public override void Down()
        {
            Delete.Table("UserAccount");
        }
    }
}