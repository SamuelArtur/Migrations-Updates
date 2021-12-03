using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V01
{
    public class InternalTransferMigration : Migration
    {
        public override void Up()
        {
            Create.Table("InternalTransfer")
                .WithColumn("InternalTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("FromAccountId").AsInt64().NotNullable()
                .WithColumn("ToAccountId").AsInt64().NotNullable()
                .WithColumn("TransferValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Attempts").AsInt64().NotNullable().WithDefault(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("FromAccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("ToAccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInternalTransfer"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferByStatus"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInternalTransferToGenerated"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferById"));
        }

        public override void Down()
        {
            Delete.Table("InternalTransfer");
        }
    }
}