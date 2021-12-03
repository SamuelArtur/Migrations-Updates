CREATE OR REPLACE FUNCTION public.updatelimitedaccount(
	"paramLimitedAccountId" bigint,
	"paramStatus" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."LimitedAccount"
	SET
		"Status" = "paramStatus",
		"UpdateUserId" = "paramUpdateUserId",
		"UpdateDate" = now()
	WHERE 
		"LimitedAccountId" = "paramLimitedAccountId" AND
		"DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatelimitedaccount(bigint, integer, bigint)
    OWNER TO "osb";