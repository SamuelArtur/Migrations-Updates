using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{  
    [Migration(19, "Create table InactivateCard")]
    public class InactivateCardMigration : Migration
    {
         public override void Up()
        {
            Create.Table("InactivateCard")
                .WithColumn("InactivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString(36).NotNullable()
                .WithColumn("ReasonCode").AsInt16().NotNullable() 
                .WithColumn("Status").AsInt16().NotNullable() 
                .WithColumn("Attempts").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");
        }

        public override void Down()
        {
            Delete.Table("InactivateCard");
        }
    }
}