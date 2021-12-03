CREATE OR REPLACE FUNCTION public.inserttopup(
	"paramAccountId" bigint,
	"paramProductType" integer,
	"paramBatchIdentifier" character varying,
	"paramProductKey" character varying,
	"paramProductValue" numeric,
	"paramContractIdentifier" character varying,
	"paramOriginNSU" character varying,
	"paramStatus" integer,
	"paramOperationId" bigint,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS TABLE("TopUpId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."TopUp"
                    (
                    "AccountId",
                    "ProductType",
                    "BatchIdentifier",
                    "ProductKey",
                    "ProductValue",
                    "ContractIdentifier",
                    "OriginNSU",
                    "Status",
					"OperationId",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId" 
                    )
	VALUES (
            "paramAccountId",
            "paramProductType",
            "paramBatchIdentifier",
            "paramProductKey",
            "paramProductValue",
            "paramContractIdentifier",
            "paramOriginNSU",
            "paramStatus",
			"paramOperationId",
            NOW(),
            NOW(),
            NULL,
            "paramCreationUserId",
            "paramUpdateUserId"
           ) RETURNING "TopUpId";
$BODY$;

ALTER FUNCTION public.inserttopup(bigint, integer, character varying, character varying, numeric, character varying, character varying, integer, bigint, bigint, bigint)
    OWNER TO "osb";
