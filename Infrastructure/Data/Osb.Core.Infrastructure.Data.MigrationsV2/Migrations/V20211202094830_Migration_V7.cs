using FluentMigrator;
using Osb.Core.Infrastructure.Data.MigrationsV2.Utils;

namespace Osb.Core.Infrastructure.Data.MigrationsV2.Migrations
{

    [Migration(20211202094830)]
    public class V20211202094830_Migration_V7 : Migration
    {

        public override void Up()
        {
            //Updating Name's Task
            Rename.Column("Name").OnTable("Account").To("Nickname");
            Rename.Column("Name").OnTable("Company").To("Nickname");
            Rename.Column("Name").OnTable("Favored").To("Nickname");
            Rename.Column("Name").OnTable("User").To("Nickname");

            //Updating Cellphone's Task
            Rename.Column("CellPhone").OnTable("User").To("Phone");

        }

        public override void Down()
        {   
            //Updating Name's Task
            Rename.Column("Nickname").OnTable("Account").To("Name");
            Rename.Column("Nickname").OnTable("Company").To("Name");
            Rename.Column("Nickname").OnTable("Favored").To("Name");
            Rename.Column("Nickname").OnTable("User").To("Name");

            //Updating Cellphone's Task
            Rename.Column("Phone").OnTable("User").To("Cellphone");

        }
        
    }
}