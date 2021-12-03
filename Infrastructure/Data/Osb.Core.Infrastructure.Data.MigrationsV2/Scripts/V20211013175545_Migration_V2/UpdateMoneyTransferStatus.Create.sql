CREATE OR REPLACE FUNCTION public.updatemoneytransferstatus(
	"paramMoneyTransferId" bigint,
	"paramStatus" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."MoneyTransfer"
		SET                
		   "Status" = "paramStatus",
		   "UpdateDate" = Now(),
		   "UpdateUserId" = '1'
		WHERE 
		   "DeletionDate" IS NULL AND
		   "MoneyTransferId" = "paramMoneyTransferId"
$BODY$;

ALTER FUNCTION public.updatemoneytransferstatus(bigint, bigint)
    OWNER TO "osb";