CREATE OR REPLACE FUNCTION public.getaccountbylastid(
	)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp with time zone, "UpdateDate" timestamp with time zone, "DeletionDate" timestamp with time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "TaxId" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
	"AccountId",
	"CompanyId",
	"Name", 
	"Type", 
	"Status",
	"CreationDate",
	"UpdateDate", 
	"DeletionDate",
	"CreationUserId", 
	"UpdateUserId", 
	"TaxId"
	FROM public."Account"
	Where
		"AccountId" = (SELECT MAX("AccountId") FROM public."Account")
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbylastid()
    OWNER TO "OSB";
