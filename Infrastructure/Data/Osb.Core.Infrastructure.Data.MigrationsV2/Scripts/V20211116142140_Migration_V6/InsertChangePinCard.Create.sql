CREATE OR REPLACE FUNCTION public.insertchangepincard(
	"paramIdentifierCard" character varying,
	"paramUserId" bigint,
	"paramAccountId" bigint,
	"paramCurrentPin" character varying,
	"paramPin" character varying,
	"paramConfirmationPin" character varying,
	"paramPinCardStatus" integer,
	"paramSalt" character varying,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."ChangePinCard"
                    (
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
                     "UpdateUserId")
    VALUES (
		    "paramIdentifierCard",
            "paramUserId",
            "paramAccountId",
            "paramCurrentPin",
            "paramPin", 
            "paramConfirmationPin",
            "paramSalt",
		    "paramPinCardStatus",
		    0,
		    NULL,
            NOW(),
            NOW(),
            "paramUpdateUserId",
            "paramUpdateUserId")
$BODY$;

ALTER FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint)
    OWNER TO "osb";

-- GRANT EXECUTE ON FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint) TO "OSB" WITH GRANT OPTION;

-- GRANT EXECUTE ON FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint) TO PUBLIC;

-- GRANT EXECUTE ON FUNCTION public.insertchangepincard(character varying, bigint, bigint, character varying, character varying, character varying, integer, character varying, bigint) TO postgres;

