CREATE OR REPLACE FUNCTION public.getmoneytransferbyexternalidentification(
	"paramExternalIdentifier" text)
    RETURNS TABLE(
		"MoneyTransferId" bigint,
		"FromAccountId" bigint, 
		"BankingDataId" bigint, 
		"TransferValue" numeric,
		"TransferDate" timestamp without time zone, 
		"Status" smallint, 
		"Description" character varying, 
		"CreationDate" timestamp without time zone,
		"UpdateDate" timestamp without time zone, 
		"DeletionDate" timestamp without time zone,
		"CreationUserId" bigint, 
		"UpdateUserId" bigint,
		"ExternalIdentifier" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "MoneyTransferId",
	   "FromAccountId",
	   "BankingDataId",
	   "TransferValue",
	   "TransferDate",
	   "Status",
	   "Description",
	   "CreationDate",
	   "UpdateDate",
	   "DeletionDate",
	   "CreationUserId",
	   "UpdateUserId",
	   "ExternalIdentifier"
	FROM public."MoneyTransfer" 
	Where
		"ExternalIdentifier" = "paramExternalIdentifier"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getmoneytransferbyexternalidentification(text)
    OWNER TO "osb";
