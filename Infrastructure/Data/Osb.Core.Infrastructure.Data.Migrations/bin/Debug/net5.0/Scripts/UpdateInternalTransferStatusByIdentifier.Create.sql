CREATE OR REPLACE FUNCTION public.updateinternaltransferstatusbyidentifier(
    "paramIdentifier" character varying , 
    "paramStatus" int)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."InternalTransfer"
			  SET
                "Status" = "paramStatus",
                "UpdateDate" = now()
		 	  WHERE 
	            "Identifier" = "paramIdentifier"
$BODY$;

ALTER FUNCTION public.updateinternaltransferstatusbyidentifier(character varying, int)
    OWNER TO "OSB";