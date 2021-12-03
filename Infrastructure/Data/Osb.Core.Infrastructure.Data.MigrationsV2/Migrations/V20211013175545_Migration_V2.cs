using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;


namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20211013175545)]
    public class V20211013175545_Migration_V2 : Migration
    {

        private string namePathScript = "V20211013175545_Migration_V2";

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

            Create.Table("BoletoPayment")
              .WithColumn("BoletoPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
              .WithColumn("UserId").AsInt64().NotNullable()
              .WithColumn("AccountId").AsInt64().NotNullable()      
              .WithColumn("Name").AsString(200).NotNullable()
              .WithColumn("TaxId").AsString(200).NotNullable()                    
              .WithColumn("ReceiverName").AsString(100).Nullable()
              .WithColumn("ReceiverTaxId").AsString(100).Nullable()      
              .WithColumn("PayerName").AsString(100).Nullable()
              .WithColumn("PayerTaxId").AsString(100).Nullable()
              .WithColumn("OperationType").AsInt32().NotNullable()
              .WithColumn("Status").AsInt32().NotNullable()      
              .WithColumn("Barcode").AsString(100).NotNullable()
              .WithColumn("PaymentValue").AsDecimal(15,2).NotNullable() 
              .WithColumn("PaymentDate").AsDateTime().NotNullable()
              .WithColumn("DueDate").AsDateTime().NotNullable()
              .WithColumn("DiscountValue").AsDecimal(15,2).NotNullable()
              .WithColumn("Description").AsString(200).NotNullable() 
              .WithColumn("Attempts").AsInt32().NotNullable()             
              .WithColumn("Identifier").AsString().NotNullable()             
              .WithColumn("ExternalIdentifier").AsString().Nullable()           
              .WithColumn("DeletionDate").AsDateTime().Nullable() 
              .WithColumn("CreationDate").AsDateTime().NotNullable()
              .WithColumn("UpdateDate").AsDateTime().NotNullable()
              .WithColumn("CreationUserId").AsInt64().NotNullable()
              .WithColumn("UpdateUserId").AsInt64().NotNullable();
				
                
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");
            
            // Create.ForeignKey()
            // .FromTable("BoletoPayment").ForeignColumn("BankingDataId")
            // .ToTable("BankingData").PrimaryColumn("BankingDataId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBoletoPayment",namePathScript));
            


            Create.Table("AccountLog")
               .WithColumn("AccountLogId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Login").AsString()
               .WithColumn("LogDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("AccountLog").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("AccountLog").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");


             Create.Table("ActivateCard")
               .WithColumn("ActivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("IdentifierCard").AsString(50).NotNullable()
               .WithColumn("Status").AsInt32().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable()
               .WithColumn("Attempts").AsInt32().WithDefaultValue(0);


             Alter.Table("Account")
                .InSchema("public")
                .AddColumn("AccountKey")
                .AsString(23)
                .WithDefaultValue("0").Nullable();

            //  Alter.Table("BankingData")
            //     .InSchema("public")
            //     .AddColumn("TaxId").AsString(20).NotNullable()
            //     .AddColumn("Name").AsString(50).NotNullable()
            //     .AddColumn("AccountType").AsInt16().NotNullable();


            // Alter.Table("Account")
            //     .InSchema("public")
            //     .AddColumn("TaxId")      -> não rodar 
            //     .AsString(14)
            //     .WithDefaultValue("0");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId",namePathScript));


            // Rename.Column("SubAccountId").OnTable("BankingData").To("BankingDataId"); -> não rodar 
 
            //Rename.Table("SubAccount").To("BankingData");  -> não rodar 


            Create.Table("AuthorizationToken")
                .WithColumn("AuthorizationTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("Code").AsString(88).NotNullable().Nullable()
                .WithColumn("Salt").AsString(36).NotNullable().Nullable()
                .WithColumn("Status").AsInt16().NotNullable()
                .WithColumn("ExpirationDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("ValidateAttempts").AsInt16().NotNullable();

              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("UpdateUserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("UserId")
              .ToTable("User").PrimaryColumn("UserId");
              Create.ForeignKey()
              .FromTable("AuthorizationToken").ForeignColumn("AccountId")
              .ToTable("Account").PrimaryColumn("AccountId");


            Create.Table("HashCode")
               .WithColumn("HashCodeId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("HashCode").AsString().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("HashCode").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("HashCode").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");


            Create.Table("InactivateCard")
                .WithColumn("InactivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString(36).NotNullable()
                .WithColumn("ReasonCode").AsInt16().NotNullable() 
                .WithColumn("Status").AsInt16().NotNullable() 
                .WithColumn("Attempts").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("InactivateCard").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");


            Create.Table("MoneyTransfer")
               .WithColumn("MoneyTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("FromAccountId").AsInt64().NotNullable()
               .WithColumn("BankingDataId").AsInt64().NotNullable()
               .WithColumn("TransferValue").AsDecimal(15,2).NotNullable()
               .WithColumn("TransferDate").AsDateTime().NotNullable()
               .WithColumn("Status").AsInt16().NotNullable()
               .WithColumn("Description").AsString().Nullable()
               .WithColumn("ExternalIdentifier").AsString().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable()
               .WithColumn("Attempts").AsInt16().NotNullable()
               .WithColumn("ToTaxId").AsString().NotNullable()
               .WithColumn("ToName").AsString().Nullable()
               .WithColumn("AccountType").AsInt16().NotNullable()
               .WithColumn("Identifier").AsString().NotNullable();
               
               
            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("BankingDataId")
            .ToTable("BankingData").PrimaryColumn("BankingDataId");
            Create.ForeignKey()
            .FromTable("MoneyTransfer").ForeignColumn("FromAccountId")
            .ToTable("Account").PrimaryColumn("AccountId");
            

            Create.Table("OutputLog")
               .WithColumn("OutputLogId").AsInt64().NotNullable().PrimaryKey()
               .WithColumn("Response").AsString().NotNullable()
               .WithColumn("LogDate").AsDateTime().NotNullable()
               .WithColumn("CreationDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().Nullable()
               .WithColumn("UpdateUserId").AsInt64().Nullable();

            Create.ForeignKey()
                .FromTable("OutputLog").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("OutputLog").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            // Alter.Table("CompanyAuthentication")
            //     .InSchema("public")
            //     .AddColumn("Salt")
            //     .AsString(36)
            //     .AlterColumn("Password")
            //     .AsString(128); -> não rodar 


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserCredentialByUserId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAuthorizationToken",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAuthorizationTokenAttempts",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAuthorizationToken",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountLog",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUser",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBankingData",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUser",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUserAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyById",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByLastId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByUserTaxId",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMoneyTransferByExternalIdentification",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateMoneyTransferStatus",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertMoneyTransfer",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPaymentAttempts",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPaymentStatus",namePathScript));
        }

        public override void Down()
        {

            Delete.Table("BoletoPayment");

            //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBoletoPayment",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentById",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPaymentAttempts",namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPaymentStatus",namePathScript));

            Delete.Table("AccountLog");

            Delete.Table("ActivateCard");

            Delete.Column("AccountKey")
                .FromTable("Account")
                .InSchema("public");

            // Delete.Column("TaxId").Column("Name").Column("AccountType")
            //     .FromTable("BankingData")
            //     .InSchema("public");


            // Delete.Column("TaxId")
            //     .FromTable("Account")
            //     .InSchema("public");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId",namePathScript));

            // Rename.Column("BankingDataId").OnTable("BankingData").To("SubAccountId");

            // Rename.Table("BankingData").To("SubAccount");

            Delete.Table("AuthorizationToken");

            Delete.Table("HashCode");

            Delete.Table("InactivateCard");

            Delete.Table("MoneyTransfer");

            Delete.Table("OutputLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserCredentialByUserId",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredentialLog",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAuthorizationToken",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAuthorizationToken",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAuthorizationTokenAttempts",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId",namePathScript));


            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyAuthenticationByAccountId",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBankingData",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountLog",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUser",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUser",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUserAccount",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyById",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByLastId",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByUserTaxId",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMoneyTransferByExternalIdentification",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateMoneyTransferStatus",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertMoneyTransfer",namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBoletoPayment",namePathScript));

            Delete.Table("BankingData");

        }
        
    }
}