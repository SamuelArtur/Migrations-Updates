CREATE OR REPLACE FUNCTION public.updateuserwebhookstatus(
	"paramUserWebhookId" bigint,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."UserWebhook"
    
    SET 
        "Status" = "paramStatus",
		"UpdateDate" = now()
    WHERE
        "UserWebhookId" = "paramUserWebhookId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updateuserwebhookstatus(bigint, integer)
    OWNER TO "osb";