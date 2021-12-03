using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;


namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20211013181130)]
    public class V20211013181130_Migration_V3 : Migration
    {

        private string namePathScript = "V20211013181130_Migration_V3";
        public override void Up()
        {
            Create.Table("ActivationToken")
               .WithColumn("ActivationTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("Code").AsString(50).NotNullable().Nullable()
               .WithColumn("ExpirationDate").AsDateTime().Nullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
            .FromTable("ActivationToken").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivationTokenByCode",namePathScript));
        }

        public override void Down()
        {
            Delete.Table("ActivationToken");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivationTokenByCode",namePathScript));
        }
        
    }
}