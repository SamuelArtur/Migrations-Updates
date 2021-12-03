CREATE OR REPLACE FUNCTION public.insertbindcard(
	"paramAccountId" bigint,
	"paramCardOwnerId" bigint,
	"paramCardHolderId" bigint,
	"paramCardHolderContactId" bigint,
	"paramIdentifierCard" character varying,
	"paramUsageType" integer,
	"paramOperationId" bigint,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."BindCard"
	(
	"AccountId",
	"CardOwnerId",
	"CardHolderId",
	"CardHolderContactId",
	"OperationId",
	"IdentifierCard",
	"UsageType",
	"CreationDate",    
    "UpdateDate",
	"CreationUserId",
	"UpdateUserId"
	)
	VALUES
	(
	"paramAccountId",
	"paramCardOwnerId",
	"paramCardHolderId",
	"paramCardHolderContactId",
	"paramOperationId",
	"paramIdentifierCard",
	"paramUsageType",
	now(),    
    now(),
	"paramCreationUserId",
	"paramUpdateUserId"
	)
RETURNING "BindCard";
$BODY$;

ALTER FUNCTION public.insertbindcard(bigint, bigint, bigint, bigint, character varying, integer, bigint, bigint, bigint)
    OWNER TO "osb";
