CREATE OR REPLACE FUNCTION public.getchangepincardbystatus(
	"paramStatus" integer)
    RETURNS TABLE("ChangePinCardId" bigint, "IdentifierCard" character varying, "UserId" bigint, "AccountId" bigint, "CurrentPin" character varying, "Pin" character varying, "ConfirmationPin" character varying, "Salt" character varying, "PinCardStatus" integer, "Attempts" integer, "DeletionDate" timestamp with time zone, "CreationDate" timestamp with time zone, "UpdateDate" timestamp with time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "ChangePinCardId",
				  "IdentifierCard",
				  "UserId",
				  "AccountId",
				  "CurrentPin",
				  "Pin",
				  "ConfirmationPin",
				  "Salt",
				  "PinCardStatus",
				  "Attempts",
				  "DeletionDate",
				  "CreationDate",
				  "UpdateDate",
				  "CreationUserId",
				  "UpdateUserId"
FROM public."ChangePinCard"
WHERE "PinCardStatus" = "paramStatus"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getchangepincardbystatus(integer)
    OWNER TO "osb";

-- GRANT EXECUTE ON FUNCTION public.getchangepincardbystatus(integer) TO "OSB" WITH GRANT OPTION;

-- GRANT EXECUTE ON FUNCTION public.getchangepincardbystatus(integer) TO PUBLIC;

-- GRANT EXECUTE ON FUNCTION public.getchangepincardbystatus(integer) TO postgres;