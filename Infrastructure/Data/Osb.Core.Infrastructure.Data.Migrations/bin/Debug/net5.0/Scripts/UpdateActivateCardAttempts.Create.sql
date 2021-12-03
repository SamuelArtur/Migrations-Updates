CREATE OR REPLACE FUNCTION public.UpdateActivateCardAttempts(
    "paramActivateCardId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ActivateCard"
			  SET
                "Attempts" = "Attempts" + 1,
                "UpdateDate" = now()
		 	  WHERE 
	            "ActivateCardId" = "paramActivateCardId"
$BODY$;

ALTER FUNCTION public.UpdateActivateCardAttempts(bigint)
    OWNER TO "OSB";