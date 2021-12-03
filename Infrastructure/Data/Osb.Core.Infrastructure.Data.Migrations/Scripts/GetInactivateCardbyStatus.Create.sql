CREATE OR REPLACE FUNCTION public.getinactivatecardbystatus(
	"paramStatus" integer,
	"paramLimit" bigint)
    RETURNS TABLE("IdentifierCardId" bigint, "AccountId" bigint, "IdentifierCard" character varying, "Pin" character varying, "Salt" character varying, "ReasonCode" smallint, "Status" smallint, "Attempts" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "InactivateCardId",
		"AccountId",
	    "IdentifierCard", 
		"Pin", 
		"Salt",
		"ReasonCode", 
		"Status", 
		"Attempts", 
		"CreationDate", 
		"UpdateDate", 
		"DeletionDate", 
		"CreationUserId",
		"UpdateUserId"
	FROM 
		public."InactivateCard"
	WHERE 	
		"Status" = "paramStatus"
	AND
		"DeletionDate" IS NULL
		limit "paramLimit";
$BODY$;

ALTER FUNCTION public.getinactivatecardbystatus(integer, bigint)
    OWNER TO "OSB";
