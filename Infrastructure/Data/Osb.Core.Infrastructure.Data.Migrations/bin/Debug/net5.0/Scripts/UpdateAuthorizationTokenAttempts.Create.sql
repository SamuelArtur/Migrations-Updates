CREATE OR REPLACE FUNCTION public.updateauthorizationtokenattempts(	
    "paramId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

UPDATE public."AuthorizationToken"
    SET 
        "ValidateAttempts" = "ValidateAttempts" + 1,
		"UpdateDate" = now()
    WHERE
        "AuthorizationTokenId" = "paramId"
$BODY$;

ALTER FUNCTION public.updateauthorizationtokenattempts(bigint)
    OWNER TO "OSB";