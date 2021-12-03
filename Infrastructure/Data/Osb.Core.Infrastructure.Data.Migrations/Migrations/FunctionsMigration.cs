using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    public class FunctionsMigration : Migration
    {
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserCredentialByUserId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserCredentialLog"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivationTokenByCode"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAuthorizationToken"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAuthorizationTokenAttempts"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAuthorizationToken"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBankingData"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertMoneyTransfer"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccount"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountLog"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUser"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAccount"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBankingData"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccount"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteAccount"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUser"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUserAccount"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyById"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByLastId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByUserTaxId"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMoneyTransferByExternalIdentification"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateMoneyTransferStatus"));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertMoneyTransfer"));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserCredentialByUserId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserCredentialLog"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivationTokenByCode"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAuthorizationToken"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAuthorizationToken"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAuthorizationTokenAttempts"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyAuthenticationByAccountId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBankingData"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccount"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountLog"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUser"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAccount"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBankingData"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccount"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteAccount"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUser"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUserAccount"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyById"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByLastId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByUserTaxId"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMoneyTransferByExternalIdentification"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateMoneyTransferStatus"));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertMoneyTransfer"));
        }
    }
}