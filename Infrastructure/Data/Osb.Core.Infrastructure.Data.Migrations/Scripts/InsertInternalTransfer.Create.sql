CREATE OR REPLACE FUNCTION public.insertinternaltransfer(
	"paramIdentifier" character varying,
	"paramOperationId" bigint
    "paramFromAccountId" bigint,
	"paramToAccountId" bigint,
	"paramTransferValue" numeric,
	"paramTransferDate" timestamp without time zone,
	"paramStatus" int,
	"paramDescription" character varying,
    "paramCreationUserId" bigint,
    "paramUpdateUserId" bigint
    )
    RETURNS TABLE("InternalTransferId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InternalTransfer"
                    (
                    "Identifier",
                    "OperationId",
                    "FromAccountId",
                    "ToAccountId",
                    "TransferValue",
                    "TransferDate",
                    "Status",
					"Description",
                    "OperationId",
                    "CreationDate",
                    "UpdateDate", 
                    "CreationUserId",
                    "UpdateUserId",                  
                     )
	VALUES (
            "paramIdentifier",
            "paramToOperationId",
            "paramFromAccountId",
            "paramToAccountId",
            "paramTransferValue",
            "paramTransferDate",
            "paramStatus",
			"paramDescription",
            now(),
            now(), 
            "paramCreationUserId",
            "paramUpdateUserId"
           ) RETURNING "InternalTransferId";
$BODY$;

ALTER FUNCTION public.insertinternaltransfer(character varying, bigint, bigint, numeric, timestamp without time zone, int, character varying, bigint, bigint)
    OWNER TO "OSB";