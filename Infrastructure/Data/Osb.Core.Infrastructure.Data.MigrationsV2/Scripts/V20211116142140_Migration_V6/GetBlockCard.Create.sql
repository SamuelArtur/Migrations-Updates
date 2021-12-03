CREATE OR REPLACE FUNCTION public.getblockcard(
	"paramId" bigint)
    RETURNS TABLE(
		"BlockCardId" bigint, 
		"IdentifierCard" character varying,
		"Pin" character varying, 
		"Salt" character varying, 
		"AccountId" bigint,
		"Attempts" integer,
		"Status" integer,
		"OperationId" bigint,
		"CreationDate" timestamp without time zone,
		"DeletionDate" timestamp without time zone,
		"UpdateDate" timestamp without time zone,
		"CreationUserId" bigint, 
		"UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "BlockCardId",
		"IdentifierCard",
		"Pin",
		"Salt",
		"AccountId",
		"Attempts",
		"Status",
		"OperationId",
		"CreationDate",
		"DeletionDate",
		"UpdateDate",
		"CreationUserId",
		"UpdateUserId"
FROM 
        public."BlockCard"
WHERE 
        "BlockCardId" = "paramId"
        AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getblockcard(bigint)
    OWNER TO "osb";