using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(9, "Create table HashCode")]
    public class HashCodeMigration : Migration
    {
        public override void Up()
        {
            Create.Table("HashCode")
               .WithColumn("HashCodeId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("HashCode").AsString().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("HashCode").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("HashCode").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
        }

        public override void Down()
        {
            Delete.Table("HashCode");
        }
    }
}