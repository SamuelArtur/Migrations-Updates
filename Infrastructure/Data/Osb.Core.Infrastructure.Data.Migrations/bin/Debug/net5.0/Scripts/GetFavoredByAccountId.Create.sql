CREATE OR REPLACE FUNCTION public.GetFavoredByAccountId(
	"paramAccountId" bigint)
    RETURNS TABLE("FavoredId" bigint, "AccountId" bigint, "TaxId" character varying, "Name" character varying, "Type" smallint, "BankName" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "CreationDate" timestamp with time zone, "UpdateDate" timestamp with time zone, "DeletionDate" timestamp with time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
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
		 "BankName",
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
		"AccountId" = "paramAccountId"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.GetFavoredByAccountId(bigint)
  OWNER TO "OSB";