using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20, "Alter Column name 'SubAccountId' to 'BankingDataId' on table 'BankingData'")]
    public class AlterColumnSubAccountIdToBankingDataIdOnBankingDataMigration : Migration
    {
        public override void Up()
        {
            Rename.Column("SubAccountId").OnTable("BankingData").To("BankingDataId");  
        }
        public override void Down()
        {
            Rename.Column("BankingDataId").OnTable("BankingData").To("SubAccountId");
        }
    }
}