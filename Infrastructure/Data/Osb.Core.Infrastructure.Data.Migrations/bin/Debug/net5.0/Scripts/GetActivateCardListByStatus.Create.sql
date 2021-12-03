CREATE OR REPLACE FUNCTION public.getactivatecardlistbystatus(
	"paramStatus" integer
    )
    RETURNS TABLE("ActivateCardId" bigint, "IdentifierCard" character varying, "Status" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint,  "Attempts" bigint, "AccountId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT "ActivateCardId",
        "IdentifierCard",
        "Status",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId",
        "Attempts",
        "AccountId"

FROM public."ActivateCard"
WHERE 
    "Status" = "paramStatus"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getactivatecardlistbystatus(integer)
    OWNER TO "OSB";