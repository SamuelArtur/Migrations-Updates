using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;



namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20211116142140)]
    public class V20211116142140_Migration_V6 : Migration
    {

        private string namePathScript = "V20211116142140_Migration_V6";
        public override void Up()
        {
           Create.Table("BindCard")
               .WithColumn("BindCardId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("CardOwnerId").AsInt64().NotNullable()
               .WithColumn("CardHolderId").AsInt64().NotNullable()
               .WithColumn("CardHolderContactId").AsInt64().NotNullable()
               .WithColumn("IdentifierCard").AsString().NotNullable()
               .WithColumn("UsageType").AsInt32().Nullable()
               .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
               .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
               .WithColumn("OperationId").AsInt64().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBindCard",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBindCard",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardListByStatus",namePathScript));


            Create.Table("BlockCard")
                .WithColumn("BlockCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("IdentifierCard").AsString().Nullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable()
                .WithColumn("ReasonCode").AsInt64().NotNullable()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("Attempts").AsInt32().WithDefaultValue(0)
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable(); 


            Create.ForeignKey()
              .FromTable("BlockCard").ForeignColumn("AccountId")
              .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCard",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCardListByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBlockCard",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBlockCard",namePathScript));


            Create.Table("CardHolder")
               .WithColumn("CardHolderId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("HolderTaxId").AsString().NotNullable()
               .WithColumn("Nationality").AsString().NotNullable()
               .WithColumn("MotherName").AsString().NotNullable()
               .WithColumn("Gender").AsInt16().NotNullable()
               .WithColumn("FullName").AsString().NotNullable()
               .WithColumn("BirthDate").AsString().NotNullable()
               .WithColumn("MaritalStatus").AsInt16().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardHolderById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardHolder",namePathScript));


            Create.Table("CardHolderContact")
               .WithColumn("CardHolderContactId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Phone").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();
            
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardHolderContactById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardHolderContact",namePathScript));


             Create.Table("CardOwner")
               .WithColumn("CardOwnerId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("OwnerTaxId").AsString().NotNullable()
               .WithColumn("FullName").AsString().NotNullable()
               .WithColumn("Phone").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("Bank").AsString().Nullable()
               .WithColumn("BankBranch").AsString().Nullable()
               .WithColumn("BankAccount").AsString().Nullable()
               .WithColumn("BankAccountDigit").AsString().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardOwnerById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardOwner",namePathScript));


            Create.Table("ChangePinCard")
               .WithColumn("ChangePinCardId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("IdentifierCard").AsString().NotNullable()
               .WithColumn("UserId").AsInt64().NotNullable()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("CurrentPin").AsString(200).NotNullable()
               .WithColumn("Pin").AsString(200).NotNullable()
               .WithColumn("ConfirmationPin").AsString(200).NotNullable()
               .WithColumn("Salt").AsString(200).NotNullable()
               .WithColumn("PinCardStatus").AsInt16().NotNullable()
               .WithColumn("Attempts").AsInt64().NotNullable().WithDefaultValue(0)
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();
            
                Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
                Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");

            //aa
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByIdentifier",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertChangePinCard",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateChangePinCard",namePathScript));
            

            Create.Table("LimitedAccount")
               .WithColumn("LimitedAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("PhoneNumber").AsString().NotNullable()
               .WithColumn("TaxId").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("Nickname").AsString().Nullable()
               .WithColumn("Bank").AsString().Nullable()
               .WithColumn("BankBranch").AsString().Nullable()
               .WithColumn("BankAccount").AsString().Nullable()
               .WithColumn("BankAccountDigit").AsString().Nullable()
               .WithColumn("BirthDate").AsDateTime().NotNullable()
               .WithColumn("TradingName").AsString().Nullable()
               .WithColumn("LegalName").AsString().Nullable()
               .WithColumn("ConstitutionDate").AsDateTime().Nullable()
               .WithColumn("Status").AsInt32().NotNullable()
               .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("LimitedAccount").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("LimitedAccount").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetLimitedAccountListByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertLimitedAccount",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateLimitedAccount",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateLimitedAccountAttempts",namePathScript));



           Create.Table("LimitedAccountCredential")
               .WithColumn("LimitedAccountCredentialId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("LimitedAccountId").AsInt64().NotNullable()
               .WithColumn("Password").AsString().NotNullable()
               .WithColumn("Salt").AsString().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("LimitedAccountCredential").ForeignColumn("LimitedAccountId")
            .ToTable("LimitedAccount").PrimaryColumn("LimitedAccountId");
            Create.ForeignKey()
            .FromTable("LimitedAccountCredential").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("LimitedAccountCredential").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");


         Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertLimitedAccountCredentials",namePathScript));



           Create.Table("LimitedPerson")
               .WithColumn("LimitedPersonId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("LimitedAccountId").AsInt64().NotNullable()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("TaxNumber").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("Phone").AsString().NotNullable()
               .WithColumn("Nickname").AsString().Nullable()
               .WithColumn("PersonRoleType").AsInt32().NotNullable()
               .WithColumn("BirthDate").AsDateTime().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            // Create.ForeignKey()
            // .FromTable("LimitedPersonCredential").ForeignColumn("LimitedPersonId")
            // .ToTable("LimitedAccount").PrimaryColumn("LimitedAccountId");
            Create.ForeignKey()
            .FromTable("LimitedPerson").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("LimitedPerson").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetLimitedPersonByLimitedAccountId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertLimitedPerson",namePathScript));


            Create.Table("NewAccount")
               .WithColumn("NewAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountId").AsInt64().NotNullable()
               .WithColumn("TaxId").AsString().NotNullable()
               .WithColumn("PersonName").AsString().NotNullable()
               .WithColumn("PhoneNumber").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("Nickname").AsString().Nullable()
               .WithColumn("BirthDate").AsDateTime().NotNullable()
               .WithColumn("MotherFullName").AsString().Nullable()
               .WithColumn("FatherFullName").AsString().Nullable()
               .WithColumn("Nationality").AsString().NotNullable()
               .WithColumn("BirthCity").AsString().NotNullable()
               .WithColumn("BirthState").AsString().NotNullable()
               .WithColumn("Gender").AsInt32().NotNullable()
               .WithColumn("Status").AsInt32().NotNullable()
               .WithColumn("MaritalStatus").AsInt32().NotNullable()
               .WithColumn("SpouseName").AsString().Nullable()
               .WithColumn("Occupation").AsString().Nullable()
               .WithColumn("CompanyType").AsInt32().NotNullable()
               .WithColumn("CompanyActivity").AsString().NotNullable()
               .WithColumn("ConstitutionDate").AsDateTime().NotNullable()
               .WithColumn("PubliclyExposedPerson").AsBoolean().NotNullable()
               .WithColumn("CheckPendingTransfers").AsBoolean().Nullable()
               .WithColumn("IdentityDocument").AsString().NotNullable()
               .WithColumn("Bank").AsString().NotNullable()
               .WithColumn("BankBranch").AsString().NotNullable()
               .WithColumn("BankAccount").AsString().NotNullable()
               .WithColumn("BankAccountDigit").AsString().NotNullable()
               .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("NewAccount").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("NewAccount").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccount",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateNewAccount",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateNewAccountAttempts",namePathScript));


            Create.Table("NewAccountAddress")
               .WithColumn("NewAccountAddressId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("NewAccountId").AsInt64().NotNullable()
               .WithColumn("AddressLine").AsString().NotNullable()
               .WithColumn("AddressLine2").AsString().NotNullable()
               .WithColumn("ZipCode").AsString().NotNullable()
               .WithColumn("Neighborhood").AsString().NotNullable()
               .WithColumn("CityCode").AsString().NotNullable()
               .WithColumn("CityName").AsString().NotNullable()
               .WithColumn("State").AsString().NotNullable()
               .WithColumn("AddressType").AsInt32().NotNullable()
               .WithColumn("Country").AsString().NotNullable()
               .WithColumn("Complement").AsString().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("NewAccountAddress").ForeignColumn("NewAccountId")
            .ToTable("NewAccount").PrimaryColumn("NewAccountId");
            Create.ForeignKey()
            .FromTable("NewAccountAddress").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("NewAccountAddress").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountAddressByNewAccountId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountAddress",namePathScript));


            Create.Table("NewAccountPerson")
               .WithColumn("NewAccountPersonId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("NewAccountId").AsInt64().NotNullable()
               .WithColumn("TaxId").AsString().NotNullable()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("Mail").AsString().NotNullable()
               .WithColumn("Occupation").AsString().Nullable()
               .WithColumn("Phone").AsString().NotNullable()
               .WithColumn("PersonRoleType").AsInt32().NotNullable()
               .WithColumn("MotherFullName").AsString().Nullable()
               .WithColumn("FatherFullName").AsString().Nullable()
               .WithColumn("Nationality").AsString().NotNullable()
               .WithColumn("BirthCity").AsString().NotNullable()
               .WithColumn("BirthState").AsString().NotNullable()
               .WithColumn("Gender").AsInt32().NotNullable()
               .WithColumn("MaritalStatus").AsInt32().NotNullable()
               .WithColumn("SpouseName").AsString().Nullable()
               .WithColumn("IdentityDocument").AsString().NotNullable()
               .WithColumn("CompanyType").AsInt32().NotNullable()
               .WithColumn("CompanyActivity").AsString().NotNullable()
               .WithColumn("ConstitutionDate").AsDateTime().NotNullable()
               .WithColumn("CheckPendingTransfers").AsBoolean().Nullable()
               .WithColumn("BirthDate").AsDateTime().NotNullable()
               .WithColumn("PersonName").AsString().NotNullable()
               .WithColumn("PhoneNumber").AsString().NotNullable()
               .WithColumn("Nickname").AsString().Nullable()
               .WithColumn("PubliclyExposedPerson").AsBoolean().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();
            
           
            Create.ForeignKey()
            .FromTable("NewAccountPerson").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("NewAccountPerson").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonByNewAccountId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountPerson",namePathScript));


          Create.Table("NewAccountPersonDocument")
               .WithColumn("NewAccountPersonDocumentId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("NewAccountId").AsInt64().Nullable()
               .WithColumn("NewAccountPersonId").AsInt64().Nullable()
               .WithColumn("DocumentFile").AsBinary().NotNullable()
               .WithColumn("DocumentFormat").AsInt32().Nullable()
               .WithColumn("DocumentName").AsString().NotNullable()
               .WithColumn("DocumentType").AsInt32().NotNullable()
               .WithColumn("Description").AsString().NotNullable()
               .WithColumn("ExpirationDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("NewAccountPersonDocument").ForeignColumn("NewAccountId")
            .ToTable("NewAccount").PrimaryColumn("NewAccountId");
            Create.ForeignKey()
            .FromTable("NewAccountPersonDocument").ForeignColumn("NewAccountPersonId")
            .ToTable("NewAccountPerson").PrimaryColumn("NewAccountPersonId");
            Create.ForeignKey()
            .FromTable("NewAccountPersonDocument").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("NewAccountPersonDocument").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertNewAccountPersonDocument",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonDocumentByNewAccountid",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetNewAccountPersonDocumentByNewAccountPersonId",namePathScript));


            Create.Table("TopUp")
                .WithColumn("TopUpId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("ProductType").AsInt32().NotNullable()
                .WithColumn("BatchIdentifier").AsString().NotNullable()
                .WithColumn("ProductKey").AsString().NotNullable()
                .WithColumn("ProductValue").AsDecimal().NotNullable()
                .WithColumn("ContractIdentifier").AsString().NotNullable()
                .WithColumn("OriginNSU").AsString().NotNullable()
                .WithColumn("UrlReceipt").AsString().Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable();

            Create.ForeignKey()
            .FromTable("TopUp").ForeignColumn("OperationId")
            .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
            .FromTable("TopUp").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("TopUp").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("TopUp").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpByExternaIidentifierAndProductKey",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertTopUp",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateTopup",namePathScript));


            // CORREÇÃO DAS TABELAS EXISTENTES]

            //Alter.Table("Account").AlterColumn("Status").AsInt64();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByAccountKey",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByLogin",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLogin",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByUserId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountsByTaxIdAndCompanyId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccount",namePathScript));

            Alter.Table("AccountWebhook").AlterColumn("Status").AsInt32();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertWebhook",namePathScript));


            Rename.Column("WhitelabelName").OnTable("Application").To("Name");

            Alter.Table("Application").AddColumn("CompanyId").AsInt64();

            Create.ForeignKey()
            .FromTable("Application").ForeignColumn("CompanyId")
            .ToTable("Company").PrimaryColumn("CompanyId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetApplicationByKey",namePathScript));



            Delete.Column("CreationDate").FromTable("OutputLog");
            Delete.Column("UpdateDate").FromTable("OutputLog");
            Delete.Column("DeletionDate").FromTable("OutputLog");
            Delete.Column("UpdateUserId").FromTable("OutputLog");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOutputLog",namePathScript));
            

            Alter.Table("User").AlterColumn("Status").AsInt32();
            Alter.Table("User").AddColumn("LoginAttempts").AsInt32();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserById",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUser",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser",namePathScript));


            Delete.Column("UpdateUserId").FromTable("UserCredentialLog");
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog",namePathScript));

            Alter.Table("UserWebhook").AlterColumn("AccountKey").AsString(23).NotNullable();
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserWebhookByStatus",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserWebhookStatus",namePathScript));

            //Updating Name's Task
            Rename.Column("Name").OnTable("Account").To("Nickname");
            Rename.Column("Name").OnTable("Company").To("Nickname");
            Rename.Column("Name").OnTable("Favored").To("Nickname");
            Rename.Column("Name").OnTable("User").To("Nickname");

            //Updating Cellphone's Task
            Rename.Column("Cellphone").OnTable("User").To("Phone");

        }

        public override void Down()
        {

           Delete.Table("TopUp");
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpByExternaIidentifierAndProductKey",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertTopUp",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateTopup",namePathScript));

           Delete.Table("NewAccountPersonDocument");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountPersonDocument",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonDocumentByNewAccountid",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonDocumentByNewAccountPersonId",namePathScript));

           Delete.Table("NewAccountPerson");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountPersonByNewAccountId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountPerson",namePathScript));

           Delete.Table("NewAccountAddress");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountAddressByNewAccountId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccountAddress",namePathScript));
   

           Delete.Table("NewAccount");
           
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetNewAccountByStatus",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertNewAccount",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateNewAccount",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateNewAccountAttempts",namePathScript));


           Delete.Table("LimitedPerson");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetLimitedPersonByLimitedAccountId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertLimitedPerson",namePathScript));


           Delete.Table("LimitedAccountCredential");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertLimitedAccountCredentials",namePathScript));

           Delete.Table("LimitedAccount");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetLimitedAccountListByStatus",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertLimitedAccount",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateLimitedAccount",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateLimitedAccountAttempts",namePathScript));

           Delete.Table("ChangePinCard");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByIdentifier",namePathScript));
          Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByStatus",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertChangePinCard",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateChangePinCard",namePathScript));

           Delete.Table("CardOwner");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardOwnerById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardOwner",namePathScript));

           Delete.Table("CardHolderContact");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardHolderContactById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardHolderContact",namePathScript));

           Delete.Table("CardHolder");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardHolderById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardHolder",namePathScript));
           
           Delete.Table("BlockCard");
           
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCard",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCardListByStatus",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBlockCard",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBlockCard",namePathScript));


           Delete.Table("BindCard");


           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBindCard",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBindCard",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardListByStatus",namePathScript));


           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByAccountKey",namePathScript));
           //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountById",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByLogin",namePathScript));
           //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLogin",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByUserId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountsByTaxIdAndCompanyId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccount",namePathScript));

          // Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertWebhook",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetApplicationByKey",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOutputLog",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserById",namePathScript));
           //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin",namePathScript));
           //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUser",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser",namePathScript));
           //Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredentialLog",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserWebhookByStatus",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserWebhookStatus",namePathScript));

            Rename.Column("Name").OnTable("Application").To("WhitelabelName");
            
            //Updating Name's Task
            Rename.Column("Name").OnTable("Account").To("Nickname");
            Rename.Column("Name").OnTable("Company").To("Nickname");
            Rename.Column("Name").OnTable("Favored").To("Nickname");
            Rename.Column("Name").OnTable("User").To("Nickname");

            //Updating Cellphone's Task
            Rename.Column("Cellphone").OnTable("User").To("Phone");


        }
        
    }
}