using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(18, "Add column TaxId to table Account")]
    public class AddTaxIdToAccount : Migration
    {
        public override void Up()
        {
            Alter.Table("Account")
                .InSchema("public")
                .AddColumn("TaxId")
                .AsString(14)
                .WithDefaultValue("0");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId"));
        }

        public override void Down()
        {
            Delete.Column("TaxId")
                .FromTable("Account")
                .InSchema("public");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId"));
        }
    }
}