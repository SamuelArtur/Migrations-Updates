CREATE OR REPLACE FUNCTION public.updatemoneytransferattempts(
	"paramId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."MoneyTransfer"
			  SET
                "Attempts" = "Attempts" + 1,
                "UpdateDate" = now()
		 	  WHERE 
	            "MoneyTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatemoneytransferattempts(bigint)
    OWNER TO "OSB";
