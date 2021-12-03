using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(16, "Adds column Salt and changes column Password length on table CompanyAuthentication")]
    public class AddSaltToCompanyAuthenticationMigration : Migration
    {
        public override void Up()
        {
            Alter.Table("CompanyAuthentication")
                .InSchema("public")
                .AddColumn("Salt")
                .AsString(36)
                .AlterColumn("Password")
                .AsString(128);

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId"));
        }

        public override void Down()
        {
        }
    }
}