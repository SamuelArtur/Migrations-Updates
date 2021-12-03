--DROP FUNCTION public.getactivationtokenbycode(character varying);

CREATE OR REPLACE FUNCTION public.getactivationtokenbycode(
	"paramCode" character varying)
    RETURNS TABLE("ActivationTokenId" bigint, "CreationUserId" bigint, "Code" character varying, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "ExpirationDate" timestamp without time zone) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "ActivationTokenId",
		"CreationUserId",
		"Code",
		"CreationDate",
		"DeletionDate",
		"ExpirationDate"
		
    FROM
		public."ActivationToken"
	Where
		"Code" = "paramCode"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getactivationtokenbycode(character varying)
    OWNER TO "osb";
