using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(8, "Create table BankingData")]
    public class BankingDataMigration : Migration
    {
        public override void Up()
        {
            Create.Table("BankingData")
               .WithColumn("BankingDataId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Bank").AsString()
               .WithColumn("BankBranch").AsString()
               .WithColumn("BankAccount").AsString()
               .WithColumn("BankAccountDigit").AsString()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
              .FromTable("BankingData").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("BankingData").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("BankingData");
        }
    }
}