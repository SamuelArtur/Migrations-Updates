using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V04
{
    public class AddOperationIdToInternalTransfer : Migration
    {
        public override void Up()
        {
            Alter.Table("InternalTransfer")
                .InSchema("public")
                .AddColumn("OperationId")
                .AsInt64().NotNullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferById"));
        }

        public override void Down()
        {
            Delete.Column("OperationId")
                .FromTable("InternalTransfer")
                .InSchema("public");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferById"));
        }
    }
}