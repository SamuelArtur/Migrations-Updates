using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V01
{

    public class FavoredMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Favored")
                .WithColumn("FavoredId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(20).NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Type").AsByte().NotNullable()
                .WithColumn("Bank").AsString(4).Nullable()
                .WithColumn("BankBranch").AsString(10).Nullable()
                .WithColumn("BankAccount").AsString(20).Nullable()
                .WithColumn("BankAccountDigit").AsString(2).Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Favored").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertFavored"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFavored"));
        }

        public override void Down()
        {
            Delete.Table("Favored");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertFavored"));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFavored"));
        }
    }
}