using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(21, "Create column 'TaxId', 'AccountType' and 'Name' on table 'BankingData'")]
    public class AddTaxIdAndAccountTypeAndNameOnBankingDataMigration : Migration
    {
        public override void Up()
        {
            Alter.Table("BankingData")
                .InSchema("public")
                .AddColumn("TaxId").AsString(20).NotNullable()
                .AddColumn("Name").AsString(50).NotNullable()
                .AddColumn("AccountType").AsInt16().NotNullable();
        }
        public override void Down()
        {
            Delete.Column("TaxId").Column("Name").Column("AccountType")
                .FromTable("BankingData")
                .InSchema("public");
        }
    }
}