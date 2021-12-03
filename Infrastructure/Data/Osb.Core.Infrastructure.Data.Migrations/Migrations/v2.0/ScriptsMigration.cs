using System;
using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V02
{
    public class ScriptsMigration : Migration
    {
        BoletoPaymentMigration _boletoPaymentMigration;

        public ScriptsMigration()
        {
            _boletoPaymentMigration = new BoletoPaymentMigration();
        }

        public override void Up()
        {
            try
            {
                _boletoPaymentMigration.Up();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {
            _boletoPaymentMigration.Down();
        }
    }
}