using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V04
{
    public class OperationMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Operation")
                .WithColumn("OperationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OperationType").AsInt16().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperation"));
        }

        public override void Down()
        {
            Delete.Table("Operation");
        }
    }
}