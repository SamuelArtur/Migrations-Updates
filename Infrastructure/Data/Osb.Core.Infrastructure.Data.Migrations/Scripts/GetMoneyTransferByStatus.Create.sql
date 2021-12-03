CREATE OR REPLACE FUNCTION public.getmoneytransferbystatus(
	"paramStatus" integer,
	"paramLimit" bigint)
    RETURNS TABLE("MoneyTransferId" bigint, "FromAccountId" bigint, "Identifier" character varying, "ToName" character varying, "ToTaxId" character varying, "BankingDataId" bigint, "TransferValue" numeric, "TransferDate" timestamp without time zone, "Status" integer, "Description" character varying, "ExternalIdentifier" character varying, "Attempts" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "MoneyTransferId",
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
		"Status" = "paramStatus"
		"DeletionDate" IS NULL
		
limit "paramLimit"
$BODY$;

ALTER FUNCTION public.getmoneytransferbystatus(integer, bigint)
    OWNER TO "OSB";