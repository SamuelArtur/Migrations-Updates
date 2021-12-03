CREATE OR REPLACE FUNCTION public.insertinternaltransfer(
	"paramIdentifier" character varying,
    "paramFromAccountId" bigint,
	"paramToAccountId" bigint,
	"paramTransferValue" numeric,
	"paramTransferDate" timestamp without time zone,
	"paramStatus" int,
	"paramDescription" character varying
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InternalTransfer"
                    (
                    "Identifier",
                    "FromAccountId",
                    "ToAccountId",
                    "TransferValue",
                    "TransferDate",
                    "Status",
					"Description",
                    "CreationDate",
                    "UpdateDate", 
                    "CreationUserId",
                    "UpdateUserId"                     
                     )
	VALUES (
            "paramIdentifier",
            "paramFromAccountId",
            "paramToAccountId",
            "paramTransferValue",
            "paramTransferDate",
            "paramStatus",
			"paramDescription",
            now(),
            now(), 
            1,
            1
           )
$BODY$;

ALTER FUNCTION public.insertinternaltransfer(character varying, bigint, bigint, numeric, timestamp without time zone, int, character varying)
    OWNER TO "osb";