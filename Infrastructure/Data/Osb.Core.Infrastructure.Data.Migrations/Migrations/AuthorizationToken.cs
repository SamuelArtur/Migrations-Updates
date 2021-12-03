using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(19, "Create table AuthorizationToken")]
    public class AuthorizationTokenMigration : Migration
    {
        public override void Up()
        {
             Create.Table("AuthorizationToken")
                .WithColumn("AuthorizationTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("Code").AsString(88).NotNullable().Nullable()
                .WithColumn("Salt").AsString(36).NotNullable().Nullable()
                .WithColumn("Status").AsInt64().NotNullable()
                .WithColumn("ExpirationDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("ValidateAttempts").AsInt64().NotNullable();

              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("AccountId")
              .ToTable("Account").PrimaryColumn("AccountId");
        }

        public override void Down()
        {
            Delete.Table("AuthorizationToken");
        }
    }
}