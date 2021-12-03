using System;
using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V04
{
    [Migration(4, "Running migrations V4")]
    public class ScriptsMigration : Migration
    {
        OperationMigration _operationMigration;
        OperationTagMigration _operationTagMigration;
        AddOperationIdToInternalTransfer _addOperationIdToInternalTransfer;

        public ScriptsMigration()
        {
            _operationMigration = new OperationMigration();
            _operationTagMigration = new OperationTagMigration();
            _addOperationIdToInternalTransfer = new AddOperationIdToInternalTransfer();
        }

        public override void Up()
        {
            try
            {
                _operationTagMigration.Up();
                _operationMigration.Up();
                _addOperationIdToInternalTransfer.Up();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {
            _operationMigration.Down();
            _operationTagMigration.Down();
            _addOperationIdToInternalTransfer.Down();
        }
    }
}