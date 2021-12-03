CREATE FUNCTION public.updateboletopaymentstatus(
	"paramBoletoPaymentId" bigint,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BoletoPayment"
		SET
		   "Status" = "paramStatus",
		   "UpdateDate" = Now(),
		   "UpdateUserId" = '1'
		WHERE 
		   "DeletionDate" IS NULL AND
		   "BoletoPaymentId" = "paramBoletoPaymentId"
$BODY$;

ALTER FUNCTION public.updateboletopaymentstatus(bigint, integer)
    OWNER TO "OSB";