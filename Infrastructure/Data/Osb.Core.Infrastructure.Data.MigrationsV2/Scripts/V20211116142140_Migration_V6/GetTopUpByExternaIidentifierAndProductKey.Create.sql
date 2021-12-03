CREATE OR REPLACE FUNCTION public.gettopupbyexternalidentifierandproductkey(
	"paramProductKey" character varying,
	"paramExternalIdentifier" bigint)
    RETURNS TABLE("TopUpId" bigint, "AccountId" bigint, "ProductType" integer, "BatchIdentifier" character varying, "ProductKey" character varying, "ProductValue" numeric, "ContractIdentifier" character varying, "OriginNSU" character varying, "UrlReceipt" character varying, "Status" integer, "Attempts" bigint, "OperationId" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "ExternalIdentifier" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	"TopUpId",
	"AccountId",
	"ProductType",
	"BatchIdentifier",
	"ProductKey",
	"ProductValue",
	"ContractIdentifier",
	"OriginNSU",
	"UrlReceipt",
	"Status",
	"Attempts",
	"OperationId",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId",
	"UpdateUserId",
	"ExternalIdentifier"	
FROM
	public."TopUp" 
WHERE
	"ProductKey" = "paramProductKey"
AND "ExternalIdentifier" = "paramExternalIdentifier"	
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.gettopupbyexternalidentifierandproductkey(character varying, bigint)
    OWNER TO "osb";