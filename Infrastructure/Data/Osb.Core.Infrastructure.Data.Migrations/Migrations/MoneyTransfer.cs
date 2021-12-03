using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(23, "Create table MoneyTransfer")]
    public class MoneyTransfer : Migration
    {
        public override void Up()
        {
            Create.Table("MoneyTransfer")
                .WithColumn("MoneyTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("FromAccountId").AsInt64().NotNullable()
                .WithColumn("FavoredId").AsInt64().NotNullable()
                .WithColumn("BankingDataId").AsInt64().NotNullable()
                .WithColumn("TransferValue").AsDecimal(10,2).NotNullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable() 
                .WithColumn("Description").AsString()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("BankingDataId")
                .ToTable("BankingData").PrimaryColumn("BankingDataId");
            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("FavoredId")
                .ToTable("Favored").PrimaryColumn("FavoredId");
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