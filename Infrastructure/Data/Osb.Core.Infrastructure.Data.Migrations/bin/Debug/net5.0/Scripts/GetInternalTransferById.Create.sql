CREATE OR REPLACE FUNCTION public.getinternaltransferbyid(
	"paramId" bigint
    )
    RETURNS TABLE("InternalTransferId" bigint, "Identifier" character varying,"FromAccountId" bigint, "ToAccountId" bigint, "TransferValue" numeric, "TransferDate" timestamp without time zone, "Status" int, "ExternalIdentifier" bigint, "Description" character varying, "Attempts" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "OperationId" bigint)
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
        "OperationId",
        "Attempts"
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId",
        "OperationId"

FROM public."InternalTransfer"

WHERE "InternalTransferId" = "paramId" AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getinternaltransferbystatus(bigint)
    OWNER TO "OSB";