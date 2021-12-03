-- FUNCTION: public.getmoneytransferbyexternalidentifier(character varying)

-- DROP FUNCTION public.getmoneytransferbyexternalidentifier(character varying);

CREATE OR REPLACE FUNCTION public.getmoneytransferbyexternalidentifier(
	"paramExternalIdentifier" character varying)
    RETURNS TABLE(
		"MoneyTransferId" bigint,
		"FromAccountId" bigint,
		"BankingDataId" bigint,
		"TransferValue" numeric,
		"TransferDate" timestamp without time zone,
		"Status" smallint,
		"Description" character varying,
		"CreationDate" timestamp without time zone,
		"DeletionDate" timestamp without time zone,
		"UpdateDate" timestamp without time zone,
		"CreationUserId" bigint,
		"UpdateUserId" bigint,
		"ExternalIdentifier" character varying,
		"Attempts" bigint,
		"ToTaxId" character varying,
		"ToName" character varying,
		"AccountType" smallint,
		"Identifier" character varying
	)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	"MoneyTransferId", 
	"FromAccountId", 
	"BankingDataId", 
	"TransferValue", 
	"TransferDate", 
	"Status", 
	"Description", 
	"CreationDate", 
	"DeletionDate", 
	"UpdateDate", 
	"CreationUserId", 
	"UpdateUserId", 
	"ExternalIdentifier", 
	"Attempts", 
	"ToTaxId", 
	"ToName", 
	"AccountType", 
	"Identifier"
	 
FROM public."MoneyTransfer"
WHERE "ExternalIdentifier" = "paramExternalIdentifier"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getmoneytransferbyexternalidentifier(character varying)
    OWNER TO "OSB";
