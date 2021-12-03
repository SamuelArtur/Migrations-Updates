CREATE OR REPLACE FUNCTION public.getfavored(
	"paramAccountId" bigint,
	"paramTaxId" character varying)
    RETURNS TABLE(
		"FavoredId" bigint, 
		"AccountId" bigint, 
		"TaxId" character varying, 
		"Name" character varying, 
		"Type" smallint, 
		"Bank" character varying, 
		"BankBranch" character varying, 
		"BankAccount" character varying, 
		"BankAccountDigit" character varying, 
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone, 
		"DeletionDate" timestamp without time zone, 
		"CreationUserId" bigint, 
		"UpdateUserId" bigint
	) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
	   "FavoredId",
	   "AccountId",
	   "TaxId",
	   "Name",
	   "Type",
	   "Bank",
	   "BankBranch",
	   "BankAccount",
	   "BankAccountDigit",
	   "CreationDate",
	   "UpdateDate",
	   "DeletionDate",
	   "CreationUserId",
	   "UpdateUserId"
	   
	FROM 
		public."Favored"
	WHERE
		("paramAccountId" NOTNULL or "AccountId" = "paramAccountId")
	AND
		("paramTaxId" IS NULL OR "TaxId" = "paramTaxId")
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getfavored(bigint, character varying)
    OWNER TO "osb";
