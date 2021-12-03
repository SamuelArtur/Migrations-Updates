using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class AccountMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Account")
               .WithColumn("AccountId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CompanyId").AsInt64().NotNullable()
               .WithColumn("BankingDataId").AsInt64().NotNullable()
               .WithColumn("Name").AsString()
               .WithColumn("Type").AsInt64().NotNullable()
               .WithColumn("Status").AsInt64().NotNullable()
               .WithColumn("TaxId").AsString()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("Account").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("Account").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("Account").ForeignColumn("CompanyId")
            .ToTable("Company").PrimaryColumn("CompanyId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById"));

        }

        public override void Down()
        {
            Delete.Table("Account");
        }
    }
}