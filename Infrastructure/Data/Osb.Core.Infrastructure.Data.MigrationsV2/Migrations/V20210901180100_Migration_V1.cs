using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;

namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20210901180100)]
    public class V20210901180100_Migration_V1 : Migration
    {

        private string namePathScript = "V20210901180100_Migration_V1";
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
                

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSubAccount",namePathScript));
                //TODO: procurar ou criar esse script que não está na branch e nem foi possível
                //localizar-lo  
                //Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetSubAccountByAccountId"));

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId",namePathScript));
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById",namePathScript));


             Create.Table("InternalTransfer")
                .WithColumn("InternalTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Identifier").AsString(50).NotNullable()
                .WithColumn("FromAccountId").AsInt64().NotNullable()
                .WithColumn("ToAccountId").AsInt64().NotNullable()
                .WithColumn("TransferValue").AsDecimal(15, 2).NotNullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Attempts").AsInt64().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

                Create.ForeignKey()
                    .FromTable("InternalTransfer").ForeignColumn("FromAccountId")
                    .ToTable("Account").PrimaryColumn("AccountId");
                Create.ForeignKey()
                    .FromTable("InternalTransfer").ForeignColumn("ToAccountId")
                    .ToTable("Account").PrimaryColumn("AccountId");
                Create.ForeignKey()
                    .FromTable("InternalTransfer").ForeignColumn("CreationUserId")
                    .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                    .FromTable("InternalTransfer").ForeignColumn("UpdateUserId")
                    .ToTable("User").PrimaryColumn("UserId");

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInternalTransfer",namePathScript));
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferByStatus",namePathScript));
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInternalTransferStatusToGenerated",namePathScript));
     

            Create.Table("Favored")

                .WithColumn("FavoredId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(20).NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Type").AsByte().NotNullable()
                .WithColumn("Bank").AsString(4).Nullable()
                .WithColumn("BankBranch").AsString(10).Nullable()
                .WithColumn("BankAccount").AsString(20).Nullable()
                .WithColumn("BankAccountDigit").AsString(2).Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("BankName").AsString(50).Nullable();

                Create.ForeignKey()
                    .FromTable("Favored").ForeignColumn("AccountId")
                    .ToTable("Account").PrimaryColumn("AccountId");

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertFavored",namePathScript));
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFavored",namePathScript));


               



        }
        

        public override void Down()
        {

            Delete.Table("SubAccount");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSubAccount",namePathScript)); 
            //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetSubAccountByAccountId"));
            
            Delete.Table("InternalTransfer");

            Delete.Table("Favored");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountById",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInternalTransfer",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateInternalTransferStatusToGenerated",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertFavored",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFavored",namePathScript));

        }

    }
}