CREATE OR REPLACE FUNCTION public.UpdateInternalTransferAttempts(
    "paramId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."InternalTransfer"
			  SET
                "Attempts" = "Attempts" + 1,
                "UpdateDate" = now()
		 	  WHERE 
	            "InternalTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.UpdateInternalTransferAttempts(bigint, int)
    OWNER TO "OSB";