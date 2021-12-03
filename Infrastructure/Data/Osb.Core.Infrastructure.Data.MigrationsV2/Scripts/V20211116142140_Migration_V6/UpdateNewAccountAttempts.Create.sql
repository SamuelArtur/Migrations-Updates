CREATE OR REPLACE FUNCTION public.updatenewaccountattempts(
	"paramNewAccountId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."NewAccount"
    
    SET 
        "Attempts" = "Attempts" + 1,
		"UpdateDate" = now()

    WHERE
        "NewAccountId" = "paramNewAccountId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatenewaccountattempts(bigint)
    OWNER TO "osb";