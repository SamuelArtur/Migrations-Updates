using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;


namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{
    [Migration(20211013181854)]
    public class V20211013181854_Migration_V4 : Migration
    {
        private string namePathScript = "V20211013181854_Migration_V4";
        public override void Up()
        {

            Create.Table("Operation")
                .WithColumn("OperationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("OperationType").AsInt32().Nullable();

            Create.Table("OperationTag")
                .WithColumn("OperationTagId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Tag").AsString(50)
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("OperationTag").ForeignColumn("OperationId")
            .ToTable("Operation").PrimaryColumn("OperationId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperationTag",namePathScript));


            Alter.Table("InternalTransfer")
                .InSchema("public")
                .AddColumn("OperationId")
                .AsInt64().NotNullable();

            

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperation",namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferById",namePathScript));

        }

        public override void Down()
        {
           Delete.Table("OperationTag");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOperationTag",namePathScript));

           Delete.Table("Operation");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOperation",namePathScript));

           Delete.Column("OperationId")
                .FromTable("InternalTransfer")
                .InSchema("public");

           Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferById",namePathScript));
        }

    }
}