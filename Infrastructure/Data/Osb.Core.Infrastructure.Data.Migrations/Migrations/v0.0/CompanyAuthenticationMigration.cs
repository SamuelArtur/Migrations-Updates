using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    public class CompanyAuthenticationMigration : Migration
    {
        public override void Up()
        {
             Create.Table("CompanyAuthentication")
                .WithColumn("CompanyAuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("Url").AsString(100).NotNullable()
                .WithColumn("UserName").AsString(100).NotNullable()
                .WithColumn("Password").AsString(100).NotNullable()
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
              
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByAccountId"));
        }

        public override void Down()
        {
            Delete.Table("CompanyAuthentication");
        }
    }
}