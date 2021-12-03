CREATE OR REPLACE FUNCTION public.inserthashcode(
    "paramHashCode" character varying
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."HashCode"
                    (                    
                    "HashCode",
                    "CreationDate",
                    "UpdateDate", 
                    "CreationUserId",
                    "UpdateUserId"                     
                     )
	VALUES (            
            "paramHashCode",
            now(),
            now(), 
            1,
            1
           )
$BODY$;

ALTER FUNCTION public.inserthashcode(character varying)
    OWNER TO "OSB";