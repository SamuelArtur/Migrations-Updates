CREATE OR REPLACE FUNCTION public.gettopupbyid(
	"paramTopUpId" bigint)
    RETURNS TABLE("TopUpId" bigint, "AccountId" bigint, "ProductType" integer, "BatchIdentifier" character varying, "ProductKey" character varying, "ProductValue" numeric, "ContractIdentifier" character varying, "OriginNSU" character varying, "ExternalIdentifier" character varying, "UrlReceipt" character varying, "Status" integer, "Attempts" integer, "OperationId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "TopUpId",
       "AccountId",
       "ProductType",
       "BatchIdentifier",
       "ProductKey",
       "ProductValue",
       "ContractIdentifier",
       "OriginNSU",
       "ExternalIdentifier",
       "UrlReceipt",
       "Status",
       "Attempts",
       "OperationId"

FROM public."TopUp"

WHERE "TopUpId" = "paramTopUpId" AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.gettopupbyid(bigint)
    OWNER TO "osb";