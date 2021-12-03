using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(19, "Alter Table name 'SubAccount' to 'BankingData'")]
    public class AlterTableNameSubAccountToBankingDataMigration : Migration
    {
        public override void Up()
        {
            Rename.Table("SubAccount").To("BankingData");
        }
        public override void Down()
        {
            Rename.Table("BankingData").To("SubAccount");
        }
    }
}