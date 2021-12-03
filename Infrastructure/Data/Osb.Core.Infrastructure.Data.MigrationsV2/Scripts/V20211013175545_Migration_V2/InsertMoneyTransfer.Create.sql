CREATE OR REPLACE FUNCTION public.insertmoneytransfer(
	"paramAccountId" bigint,
	"paramBankingDataId" bigint,
	"paramTransferValue" numeric,
	"paramTransferDate" timestamp without time zone,
	"paramStatus" integer,
	"paramDescription" character varying,
	"paramExternalIdentifier" character varying)
    RETURNS TABLE("MoneyTransferId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."MoneyTransfer"(
					"FromAccountId",
					"BankingDataId",
					"TransferValue",
					"TransferDate",
					"Status",
					"Description",
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId",
					"ExternalIdentifier"
					)

			VALUES (
					"paramAccountId",
					"paramBankingDataId",
					"paramTransferValue",
					"paramTransferDate",
					"paramStatus",
					"paramDescription",
					Now(),
					Now(),
					1,
					1,
					"paramExternalIdentifier") RETURNING "MoneyTransferId";
$BODY$;

ALTER FUNCTION public.insertmoneytransfer(bigint, bigint, numeric, timestamp without time zone, integer, character varying, character varying)
    OWNER TO "osb";