using System;
using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V01
{
    [Migration(1, "Running migrations V1")]
    public class ScriptsMigration : Migration
    {
        InternalTransferMigration _internalTrasnferMigration;
        FavoredMigration _favoredMigration;

        public ScriptsMigration()
        {
            _internalTrasnferMigration = new InternalTransferMigration();
            _favoredMigration = new FavoredMigration();
        }

        public override void Up()
        {
            try
            {
                _internalTrasnferMigration.Up();
                _favoredMigration.Up();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {
            _internalTrasnferMigration.Down();
             _favoredMigration.Down();
        }
    }
}