CREATE OR REPLACE FUNCTION public.getmoneytransferbyid(
	"paramId" bigint)
    RETURNS TABLE("MoneyTransferId" bigint, "FromAccountId" bigint, "Identifier" character varying, "ToName" character varying, "ToTaxId" character varying, "BankingDataId" bigint, "TransferValue" numeric, "TransferDate" timestamp without time zone, "Status" integer, "Description" character varying, "ExternalIdentification" character varying, "Attempts" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  
	"MoneyTransferId",
	"FromAccountId" As "AccountId", 
	"Identifier", 
	"ToName",
	"ToTaxId", 
	"BankingDataId", 
	"TransferValue", 
	"TransferDate", 
	"Status", 
	"Description", 
	"ExternalIdentifier",
	"Attempts"
FROM 
	public."MoneyTransfer"
WHERE 
	"MoneyTransferId" = "paramId" 
	AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getmoneytransferbyid(bigint)
    OWNER TO "OSB";