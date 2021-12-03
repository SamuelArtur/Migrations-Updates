using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;



namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20211015183120)]
    public class V20211015183120_Migration_V5 : Migration
    {

        private string namePathScript = "V20211015183120_Migration_V5";
        public override void Up()
        {
           Create.Table("UserWebhook")
               .WithColumn("UserWebhookId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CompanyId").AsInt64().NotNullable()
               .WithColumn("TaxId").AsString(14).NotNullable()
               .WithColumn("Name").AsString(200).NotNullable()
               .WithColumn("Mail").AsString(50).NotNullable()
               .WithColumn("CellPhone").AsString(50).NotNullable()
               .WithColumn("AccountName").AsString(200).NotNullable()
               .WithColumn("AccountTaxId").AsString(14).NotNullable()
               .WithColumn("Status").AsInt32().NotNullable()
               .WithColumn("EventType").AsInt64().NotNullable()
               .WithColumn("UserTaxId").AsString(14).NotNullable()
               .WithColumn("AccountKey").AsString(23).Nullable()
               .WithColumn("Password").AsString(150).NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
              .FromTable("UserWebhook").ForeignColumn("CreationUserId")
              .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserWebhook").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserWebhook",namePathScript));      



            Create.Table("UserInformation")
                .WithColumn("UserInformationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("CellPhone").AsString().NotNullable()
                .WithColumn("ZipCode").AsString().NotNullable()
                .WithColumn("Street").AsString().NotNullable()
                .WithColumn("Number").AsString().NotNullable()
                .WithColumn("District").AsString().NotNullable()
                .WithColumn("Complement").AsString().NotNullable()
                .WithColumn("City").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable();

                Create.ForeignKey()
                    .FromTable("UserInformation").ForeignColumn("CreationUserId")
                    .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                    .FromTable("UserInformation").ForeignColumn("UpdateUserId")
                    .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                    .FromTable("UserInformation").ForeignColumn("UserId")
                    .ToTable("User").PrimaryColumn("UserId");



            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserInformation",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserInformationByUserId",namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserInformation",namePathScript));


            Create.Table("AccountWebhook")
               .WithColumn("AccountWebhookId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("AccountConditionType").AsInt64().NotNullable()
               .WithColumn("AccountStatus").AsInt64().NotNullable()
               .WithColumn("AccountKey").AsString(23).Nullable()
               .WithColumn("AccountCreationDate").AsDateTime().Nullable()
               .WithColumn("AccountConditionId").AsInt64().NotNullable()               
               .WithColumn("PartnerId").AsInt64().NotNullable()
               .WithColumn("BusinessUnitId").AsInt64().NotNullable()
               .WithColumn("Identifier").AsInt64().NotNullable()           
               .WithColumn("TaxNumber").AsString(14).NotNullable()
               .WithColumn("FromBank").AsString().Nullable()
               .WithColumn("FromBankBranch").AsString().Nullable()
               .WithColumn("FromBankAccount").AsString().Nullable()
               .WithColumn("FromBankAccountDigit").AsString().Nullable()
               .WithColumn("SendDate").AsDateTime().NotNullable()
               .WithColumn("ToBank").AsString().Nullable()
               .WithColumn("ToBankBranch").AsString().Nullable()
               .WithColumn("ToBankAccount").AsString().Nullable()
               .WithColumn("ToBankAccountDigit").AsString().Nullable()
               .WithColumn("Method").AsString().Nullable()    
               .WithColumn("Status").AsInt64().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("AccountWebhook").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("AccountWebhook").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
                
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountWebhook",namePathScript));


                 Create.Table("Authentication")
                    .WithColumn("AuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                    .WithColumn("UrlApi").AsString(150).NotNullable()
                    .WithColumn("Token").AsString(50).NotNullable()
                    .WithColumn("Username").AsString(50).NotNullable()
                    .WithColumn("Password").AsString(150).NotNullable()
                    .WithColumn("Salt").AsString(50).Nullable()
                    .WithColumn("ApplicationId").AsInt64().NotNullable()
                    .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable()
                    .WithColumn("CreationUserId").AsInt64().NotNullable()
                    .WithColumn("UpdateUserId").AsInt64().NotNullable()
                    .WithColumn("CreationDate").AsDateTime().NotNullable()
                    .WithColumn("UpdateDate").AsDateTime().NotNullable()
                    .WithColumn("DeletionDate").AsDateTime().Nullable();

                    
                    Create.ForeignKey()
                    .FromTable("Authentication").ForeignColumn("ApplicationId")
                    .ToTable("Application").PrimaryColumn("ApplicationId");
                    Create.ForeignKey()
                    .FromTable("Authentication").ForeignColumn("CompanyAuthenticationId")
                    .ToTable("CompanyAuthentication").PrimaryColumn("CompanyAuthenticationId");
                    Create.ForeignKey()
                    .FromTable("Authentication").ForeignColumn("CreationUserId")
                    .ToTable("User").PrimaryColumn("UserId");
                    Create.ForeignKey()
                    .FromTable("Authentication").ForeignColumn("UpdateUserId")
                    .ToTable("User").PrimaryColumn("UserId");


        }

        public override void Down()
        {
           Delete.Table("UserWebhook");
           
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserWebhook",namePathScript));

           Delete.Table("UserInformation");
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserInformation",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserInformationByUserId",namePathScript));
           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserInformation",namePathScript));

           Delete.Table("AccountWebhook");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountWebhook",namePathScript));

        }
        
    }
}