using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20, "Create table BoletoPayment")]
    public class BoletoPaymentMigration : Migration
    {
        public override void Up()
        {
            Create.Table("BoletoPayment")
              .WithColumn("BoletoPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
              .WithColumn("UserId").AsInt64().NotNullable()
              .WithColumn("AccountId").AsInt64().NotNullable()
              .WithColumn("BankingDataId").AsInt64().NotNullable()      
              .WithColumn("Name").AsString(200).NotNullable()
              .WithColumn("TaxId").AsString(200).NotNullable()                    
              .WithColumn("ReceiverName").AsString(100).NotNullable()
              .WithColumn("ReceiverTaxId").AsString(100).NotNullable()      
              .WithColumn("PayerName").AsString(100).NotNullable()
              .WithColumn("PayerTaxId").AsString(100).NotNullable()
              .WithColumn("OperationType").AsInt16().NotNullable()
              .WithColumn("Status").AsInt16().NotNullable()      
              .WithColumn("Barcode").AsString(100).NotNullable()
              .WithColumn("PaymentValue").AsDecimal().NotNullable() 
              .WithColumn("PaymentDate").AsDateTime().NotNullable()
              .WithColumn("DueDate").AsDateTime().NotNullable()
              .WithColumn("DiscountValue").AsDecimal().NotNullable()
              .WithColumn("Description").AsString(200).NotNullable() 
              .WithColumn("Attempts").AsInt64().NotNullable()             
              .WithColumn("Identifier").AsString(50).NotNullable()             
              .WithColumn("ExternalIdentifier").AsInt64().NotNullable()             
              .WithColumn("DeletionDate").AsDateTime().Nullable() 
              .WithColumn("CreationDate").AsDateTime().NotNullable()
              .WithColumn("UpdateDate").AsDateTime().NotNullable()
              .WithColumn("CreationUserId").AsInt64().NotNullable()
              .WithColumn("UpdateUserId").AsInt64().NotNullable();
				
                
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");
            
            Create.ForeignKey()
            .FromTable("BoletoPayment").ForeignColumn("BankingDataId")
            .ToTable("BankingData").PrimaryColumn("BankingDataId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBoletoPaymentById"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentById"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentByStatus"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPaymentAttempts"));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPaymentStatus"));
        }
        public override void Down()
        {
            Delete.Table("BoletoPayment");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBoletoPaymentById"));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentById"));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentByStatus"));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPaymentAttempts"));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPaymentStatus"));
        }
    }
}