-- FUNCTION: public.getboletopaymentbystatus(integer)

-- DROP FUNCTION public.getboletopaymentbystatus(integer);

CREATE OR REPLACE FUNCTION public.getboletopaymentbystatus(
	"paramStatus" integer)
    RETURNS TABLE("BoletoPaymentId" bigint, 
    "UserId" bigint, 
    "AccountId" bigint, 
    "Name" character varying, 
    "TaxId" character varying, 
    "ReceiverName" character varying,
    "ReceiverTaxId" character varying,
    "PayerName" character varying,
    "PayerTaxId" character varying, 
    "OperationType" integer, 
    "Status" integer,
    "Barcode" character varying, 
    "PaymentValue" numeric, 
    "PaymentDate" timestamp without time zone, 
    "DueDate" timestamp without time zone, "DiscountValue" numeric,
    "Description" character varying, 
    "Attempts" integer, 
    "Identifier" character varying,
    "ExternalIdentifier" character varying,
    "DeletionDate" timestamp without time zone, 
    "CreationDate" timestamp without time zone,
    "UpdateDate" timestamp without time zone,
    "CreationUserId" bigint, 
    "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	   "BoletoPaymentId",
        "UserId",
        "AccountId",
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
WHERE "Status" = "paramStatus"
$BODY$;

ALTER FUNCTION public.getboletopaymentbystatus(integer)
    OWNER TO "osb";
