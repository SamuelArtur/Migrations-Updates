using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{

    [Migration(20210901175701)]
    public class V20210901175701_Migration_V0 : Migration
    {
      private string namePathScript = "V20210901175701_Migration_V0";
        public override void Up()
        {

          Create.Table("User")
               .WithColumn("UserId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("Login").AsString(50).NotNullable()
               .WithColumn("Name").AsString(50).NotNullable()
               .WithColumn("Mail").AsString(50).NotNullable()
               .WithColumn("CellPhone").AsString(50).Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("Status").AsInt16().Nullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

               Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin",namePathScript));

            Create.Table("Company")
                .WithColumn("CompanyId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

                Create.ForeignKey()
                .FromTable("Company").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("Company").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");



          Create.Table("Application")
                .WithColumn("ApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("WhitelabelName").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("Key").AsString(128).NotNullable()
                .WithColumn("Secret").AsString(128).Nullable()
                .WithColumn("Salt").AsString(36).NotNullable();
        
                Create.ForeignKey()
                .FromTable("Application").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("Application").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");


            Create.Table("Account")
               .WithColumn("AccountId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CompanyId").AsInt64().NotNullable()
               .WithColumn("SubAccountId").AsInt64().Nullable().WithDefaultValue(null)
               .WithColumn("Name").AsString()
               .WithColumn("Type").AsInt64().Nullable().WithDefaultValue(0)
               .WithColumn("Status").AsInt64().NotNullable().WithDefaultValue(0)
               .WithColumn("TaxId").AsString(14).Nullable()
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


          Create.Table("CompanyAuthentication")
                .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("Url").AsString(100).NotNullable()
                .WithColumn("Salt").AsString(36)
                .WithColumn("UserName").AsString(255).NotNullable()
                .WithColumn("Password").AsString(255).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

                Create.ForeignKey()
                .FromTable("CompanyAuthentication").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("CompanyAuthentication").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("CompanyAuthentication").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
                
                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId",namePathScript));


          Create.Table("InputLog")
                .WithColumn("InputLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Request").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable();



          Create.Table("UserAccount")
                .WithColumn("UserAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

                Create.ForeignKey()
                .FromTable("UserAccount").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserAccount").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserAccount").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserAccount").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");


           Create.Table("UserApplication")
                .WithColumn("UserApplicationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ApplicationId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();
        
                Create.ForeignKey()
                .FromTable("UserApplication").ForeignColumn("ApplicationId")
                .ToTable("Application").PrimaryColumn("ApplicationId");
                Create.ForeignKey()
                .FromTable("UserApplication").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");

                Create.ForeignKey()
                .FromTable("UserApplication").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserApplication").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

          Create.Table("UserCredential")
                .WithColumn("UserCredentialId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Password").AsString(150).NotNullable()
                .WithColumn("Salt").AsString(36)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

                Create.ForeignKey()
                .FromTable("UserCredential").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserCredential").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserCredential").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserCredentialByUserId",namePathScript));


          Create.Table("UserCredentialLog")
                .WithColumn("UserCredentialLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Login").AsString(50).NotNullable()
                .WithColumn("LogDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().Nullable();


                
          Create.ForeignKey()
                .FromTable("UserCredentialLog").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
                .FromTable("UserCredentialLog").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
                Create.ForeignKey()
               .FromTable("UserCredentialLog").ForeignColumn("UpdateUserId")
               .ToTable("User").PrimaryColumn("UserId");

                Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog",namePathScript));
            

        }
        

        public override void Down()
        {

            Delete.Table("UserCredentialLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredentialLog",namePathScript));

            Delete.Table("UserCredential");

            Delete.Table("UserApplication");

            Delete.Table("UserAccount");

            Delete.Table("InputLog");

            Delete.Table("Account");

            Delete.Table("Authentication");

            Delete.Table("CompanyAuthentication");

            Delete.Table("Application");

            Delete.Table("Company");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin",namePathScript));

            Delete.Table("User");
        }

    }
}