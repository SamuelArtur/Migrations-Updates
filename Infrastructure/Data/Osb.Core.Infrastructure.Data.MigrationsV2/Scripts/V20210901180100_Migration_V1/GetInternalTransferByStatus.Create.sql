CREATE OR REPLACE FUNCTION public.getinternaltransferbystatus(
	"paramStatus" int,
    "paramLimit" bigint)
    RETURNS TABLE("InternalTransferId" bigint, "Identifier" character varying, "FromAccountId" bigint, "ToAccountId" bigint, "TransferValue" numeric, "TransferDate" timestamp without time zone, "Status" smallint, "ExternalIdentifier" bigint, "Description" character varying, "Attempts" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT "InternalTransferId",
        "Identifier",
        "FromAccountId",
        "ToAccountId",
        "TransferValue",
        "TransferDate",
        "Status",
        "ExternalIdentifier",
        "Description",
        "Attempts",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."InternalTransfer"

WHERE "Status" = "paramStatus"

limit "paramLimit"

$BODY$;
ALTER FUNCTION public.getinternaltransferbystatus(int, bigint)
    OWNER TO "osb";