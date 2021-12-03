using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V04
{
    public class OperationTagMigration : Migration
    {
        public override void Up()
        {
            Create.Table("OperationTag")
                .WithColumn("OperationTagId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Tag").AsString()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("OperationTag").ForeignColumn("OperationId")
            .ToTable("Operation").PrimaryColumn("OperationId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperationTag"));
        }

        public override void Down()
        {
            Delete.Table("OperationTag");
        }
    }
}