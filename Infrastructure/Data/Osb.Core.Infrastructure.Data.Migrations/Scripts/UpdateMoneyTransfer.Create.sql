-- FUNCTION: public.updatemoneytransfer(bigint, character varying, integer, integer)

-- DROP FUNCTION public.updatemoneytransfer(bigint, character varying, integer, integer);

CREATE OR REPLACE FUNCTION public.updatemoneytransfer(
	"paramId" bigint,
	"paramExternalIdentifier" character varying,
	"paramStatus" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."MoneyTransfer"
	SET                
		"Status" = "paramStatus",
		"ExternalIdentifier" = "paramExternalIdentifier",
		"UpdateDate" = Now(),
		"UpdateUserId" = "paramUpdateUserId"
	WHERE 
		"DeletionDate" IS NULL AND
		"MoneyTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatemoneytransfer(bigint, character varying, integer, bigint)
    OWNER TO "OSB";
