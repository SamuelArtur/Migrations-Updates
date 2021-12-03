CREATE OR REPLACE FUNCTION public.updatechangepincard(
	"paramChangePinCardId" bigint,
	"paramIdentifierCard" character varying,
	"paramUpdateUserId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ChangePinCard"
		SET
		   "PinCardStatus" = "paramStatus",
		   "Attempts" = "paramAttempts",
		   "UpdateDate" = Now(),
		   "UpdateUserId" = "paramUpdateUserId"
		WHERE 
		   "DeletionDate" IS NULL AND
		   "ChangePinCardId" = "paramChangePinCardId" AND
		   "IdentifierCard" = "paramIdentifierCard"
$BODY$;

ALTER FUNCTION public.updatechangepincard(bigint, character varying, bigint, integer, integer)
    OWNER TO "osb";