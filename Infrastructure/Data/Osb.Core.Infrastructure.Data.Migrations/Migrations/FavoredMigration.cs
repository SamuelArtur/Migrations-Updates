using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(22, "Create table 'Favored'")]
    public class FavoredMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Favored")
                .WithColumn("FavoredId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(20).NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Type").AsInt64().NotNullable()
                .WithColumn("BankName").AsString(50).Nullable()
                .WithColumn("Bank").AsString(4).Nullable()
                .WithColumn("BankBranch").AsString(10).Nullable()
                .WithColumn("BankAccount").AsString(20).Nullable()
                .WithColumn("BankAccountDigit").AsString(2).Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();
        
            Create.ForeignKey()
                .FromTable("Favored").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
        }

        public override void Down()
        {
            Delete.Table("Favored");
        }
    }
}