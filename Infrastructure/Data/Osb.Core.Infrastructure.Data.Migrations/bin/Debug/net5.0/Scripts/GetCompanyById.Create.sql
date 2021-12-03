CREATE OR REPLACE FUNCTION public.getcompanybyid(
	"paramCompanyId" bigint)
    RETURNS TABLE("CompanyId" bigint, "Name" character varying, "CreationDate" timestamp with time zone, "UpdateDate" timestamp with time zone, "DeletionDate" timestamp with time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
	   "CompanyId",
	   "Name",
	   "CreationDate",
	   "UpdateDate",
	   "DeletionDate",
	   "CreationUserId",
	   "UpdateUserId"
	FROM 
		public."Company" 
	Where
		"CompanyId" = "paramCompanyId"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getcompanybyid(bigint)
    OWNER TO "OSB";