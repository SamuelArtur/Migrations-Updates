DROP FUNCTION public.getboletopaymentbystatus(integer);

CREATE OR REPLACE FUNCTION public.getboletopaymentbystatus(
	"paramStatus" integer)
    RETURNS TABLE("BoletoPaymentId" bigint, "UserId" bigint, "AccountId" bigint, "SubAccountId" bigint, "Name" character varying, "TaxId" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "ReceiverName" character varying, "ReceiverTaxId" character varying, "PayerName" character varying, "PayerTaxId" character varying, "Barcode" character varying, "OperationType" integer, "Status" integer, "PaymentValue" numeric, "PaymentDate" timestamp without time zone, "DueDate" timestamp without time zone, "DiscountValue" numeric, "Description" character varying, "Attempts" integer, "DeletionDate" timestamp without time zone, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	   "BoletoPaymentId",
	   "UserId",
	   "AccountId",
	   "SubAccountId",
	   "Name",
	   "TaxId",
	   "Bank",
	   "BankBranch",
	   "BankAccount",
	   "BankAccountDigit",
	   "ReceiverName",
	   "ReceiverTaxId",
	   "PayerName",
	   "PayerTaxId",
	   "Barcode",
	   "OperationType",
	   "Status",
	   "PaymentValue",
	   "PaymentDate",
	   "DueDate",
	   "DiscountValue",
	   "Description",
	   "Attempts",
	   "DeletionDate",
	   "CreationDate",
	   "UpdateDate",
	   "CreationUserId",
	   "UpdateUserId"
FROM public."BoletoPayment" 
WHERE "Status" = "paramStatus"
$BODY$;

ALTER FUNCTION public.getboletopaymentbystatus(integer)
    OWNER TO "OSB";
