CREATE OR REPLACE FUNCTION public.updatelimitedaccountattempts(
	"paramLimitedAccountId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."LimitedAccount"
			  SET
                "Attempts" = "Attempts" + 1,
                "UpdateDate" = now()
		 	  WHERE 
	            "LimitedAccountId" = "paramLimitedAccountId"
$BODY$;

ALTER FUNCTION public.updatelimitedaccountattempts(bigint)
    OWNER TO "osb";