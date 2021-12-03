using System;
using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V03
{
    [Migration(0, "Create table ActivationToken")]
    public class ScriptsMigration : Migration
    {
        ActivationTokenMigration _activationTokenMigration;

        public ScriptsMigration()
        {
            _activationTokenMigration = new ActivationTokenMigration();
        }

        public override void Up()
        {
            try
            {
                _activationTokenMigration.Up();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {
            _activationTokenMigration.Down();
        }
    }
}