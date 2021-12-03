using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{

    [Migration(17, "Add column AccountKey to table Account")]
    public class AddAccountKeyToAccount : Migration
    {
        public override void Up()
        {
            Alter.Table("Account")
                .InSchema("public")
                .AddColumn("AccountKey")
                .AsString(23)
                .WithDefaultValue("0");
        }
        public override void Down()
        {
            Delete.Column("AccountKey")
                .FromTable("Account")
                .InSchema("public");
        }
    }
}