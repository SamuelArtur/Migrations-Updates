using System;
using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations.V00
{
    [Migration(0, "Running migrations V0")]
    public class ScriptsMigration : Migration
    {
        UserMigration _userMigration;
        ApplicationMigration _applicationMigration;
        CompanyMigration _companyMigration;
        CompanyAuthenticationMigration _companyAuthenticationMigration;
        InputLogMigration _inputLogMigration;
        UserAccountMigration _userAccountMigration;
        UserApplicationMigration _userApplicationMigration;
        UserCredentialMigration _userCredentialMigration;
        UserCredentialLogMigration _userCredentialLogMigration;

        public ScriptsMigration()
        {
            _userMigration = new UserMigration();
            _applicationMigration = new ApplicationMigration();
            _companyMigration = new CompanyMigration();
            _companyAuthenticationMigration = new CompanyAuthenticationMigration();
            _inputLogMigration = new InputLogMigration();
            _userAccountMigration = new UserAccountMigration();
            _userApplicationMigration = new UserApplicationMigration();
            _userCredentialMigration = new UserCredentialMigration();
            _userCredentialLogMigration = new UserCredentialLogMigration();
        }
        public override void Up()
        {
            try
            {
                _userMigration.Up();
                _applicationMigration.Up();
                _companyMigration.Up();
                _companyAuthenticationMigration.Up();
                _inputLogMigration.Up();
                _userAccountMigration.Up();
                _userApplicationMigration.Up();
                _userCredentialMigration.Up();
                _userCredentialLogMigration.Up();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Down()
        {
            _userMigration.Down();
            _applicationMigration.Down();
            _companyMigration.Down();
            _companyAuthenticationMigration.Down();
            _inputLogMigration.Down();
            _userAccountMigration.Down();
            _userApplicationMigration.Down();
            _userCredentialMigration.Down();
            _userCredentialLogMigration.Down();
        }
    }
}