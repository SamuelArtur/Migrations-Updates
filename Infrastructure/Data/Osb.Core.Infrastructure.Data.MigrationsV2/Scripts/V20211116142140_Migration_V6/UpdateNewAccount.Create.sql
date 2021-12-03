CREATE OR REPLACE FUNCTION public.updatenewaccount(
	"paramNewAccountId" bigint,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."NewAccount"
    
    SET 
        "Status" = "paramStatus",
		"UpdateDate" = now()
    WHERE
        "NewAccountId" = "paramNewAccountId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatenewaccount(bigint, integer)
    OWNER TO "osb";