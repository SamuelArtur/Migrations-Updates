using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(18, "Create table MoneyTransfer")]
    public class MoneyTransferMigration : Migration
    {
        public override void Up()
        {
            Create.Table("MoneyTransfer")
               .WithColumn("MoneyTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("FromAccountId").AsInt64().NotNullable()
               .WithColumn("BankingDataId").AsInt64().NotNullable()
               .WithColumn("TransferValue").AsDecimal().NotNullable()
               .WithColumn("TransferDate").AsDateTime().NotNullable()
               .WithColumn("Status").AsInt64().NotNullable()
               .WithColumn("Description").AsString().NotNullable()
               .WithColumn("ExternalIdentification").AsString().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("BankingDataId")
            .ToTable("BankingData").PrimaryColumn("BankingDataId");
            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("FromAccountId")
            .ToTable("Account").PrimaryColumn("AccountId");
        }

        public override void Down()
        {
            Delete.Table("MoneyTransfer");
        }
    }
}