--DROP FUNCTION public.getboletopaymentbyid(bigint);

CREATE OR REPLACE FUNCTION public.getboletopaymentbyid(
	"paramId" bigint)
    RETURNS TABLE("BoletoPaymentId" bigint, "UserId" bigint, "AccountId" bigint, "BankingDataId" bigint, "Name" character varying, "TaxId", "ReceiverName" character varying, "ReceiverTaxId" character varying, "PayerName" character varying, "PayerTaxId" character varying, "OperationType" smallint, "Status" smallint, "Barcode" character varying, "PaymentValue" numeric, "PaymentDate" timestamp without time zone, "DueDate" timestamp without time zone, "DiscountValue" numeric, "Description" character varying, "Attempts" integer, "Identifier" character varying, "ExternalIdentifier" character varying, "DeletionDate" timestamp without time zone, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT "BoletoPaymentId",
        "UserId",
        "AccountId",
        "BankingDataId",
        "Name",
        "TaxId",
        "ReceiverName",
        "ReceiverTaxId",
        "PayerName",
        "PayerTaxId",
        "OperationType",
        "Status",
        "Barcode",
        "PaymentValue",
        "PaymentDate",
        "DueDate",
        "DiscountValue",
        "Description",
        "Attempts",
        "Identifier",
        "ExternalIdentifier",
        "DeletionDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."BoletoPayment"
WHERE "BoletoPaymentId" = "paramId"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getboletopaymentbyid(bigint)
    OWNER TO "OSB";