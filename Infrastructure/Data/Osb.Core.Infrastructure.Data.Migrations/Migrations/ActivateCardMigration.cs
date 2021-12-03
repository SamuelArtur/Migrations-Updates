using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(25, "Create table ActivateCard")]
    public class ActivateCardMigration : Migration
    {
        public override void Up()
        {
            Create.Table("ActivateCard")
               .WithColumn("ActivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("CardIdentifier").AsString().NotNullable()
               .WithColumn("Status").AsInt16().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable()
               .WithColumn("Attempts").AsInt16().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("ActivateCard");
        }
    }
}