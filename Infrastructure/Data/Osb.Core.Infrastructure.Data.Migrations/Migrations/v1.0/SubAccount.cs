using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V01
{
    public class SubAccountMigration : Migration
    {
        public override void Up()
        {
            Create.Table("SubAccount")
               .WithColumn("SubAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
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
              .FromTable("SubAccount").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("SubAccount").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("SubAccount").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSubAccount"));  
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetSubAccountByAccountId"));    
        }

        public override void Down()
        {
            Delete.Table("SubAccount");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSubAccount")); 
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetSubAccountByAccountId"));   
        }
    }
}