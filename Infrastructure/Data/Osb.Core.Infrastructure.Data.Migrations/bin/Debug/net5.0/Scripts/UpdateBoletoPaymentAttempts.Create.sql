CREATE FUNCTION public.updateboletopaymentattempts(
	"paramBoletoPaymentId" bigint, 
	"paramAttempts" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BoletoPayment"
			  SET
                "Attempts" = "paramAttempts",
                "UpdateDate" = now()
		 	  WHERE
			  	"DeletionDate" IsNull AND
	            "BoletoPaymentId" = "paramBoletoPaymentId"
$BODY$;

ALTER FUNCTION public.updateboletopaymentattempts(bigint, integer)
    OWNER TO "OSB";