CREATE OR REPLACE FUNCTION public.getuserbyid(
	"paramUserId" bigint)
    RETURNS TABLE("UserId" bigint, "Login" character varying, "Name" character varying, "Mail" character varying, "CellPhone" character varying, "Status" integer, "LoginAttempts" integer, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "UserId",
		"Login", 
		"Name", 
		"Mail", 
		"CellPhone",
		"Status",
		"LoginAttempts",
		"CreationDate", 
		"DeletionDate", 
		"UpdateDate",
		"CreationUserId", 
		"UpdateUserId"
    FROM
		public."User"
	Where
		"UserId" = "paramUserId"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getuserbyid(bigint)
    OWNER TO "osb";
