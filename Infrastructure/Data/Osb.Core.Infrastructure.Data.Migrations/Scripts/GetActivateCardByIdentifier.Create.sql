CREATE OR REPLACE FUNCTION public.getactivatecardbyidentifier(
	"paramIdentifierCard" character varying
    )
    RETURNS TABLE("ActivateCardId" bigint, "IdentifierCard" character varying, "Status" int, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint,  "Attempts" bigint, "AccountId" bigint)
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
    "IdentifierCard" = "paramIdentifierCard"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getactivatecardbyidentifier(character varying)
    OWNER TO "OSB";