CREATE OR REPLACE FUNCTION public.updateboletopaymentstatusbyidentifier(
	"paramIdentifier" character varying,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BoletoPayment"
			  SET
                "Status" = "paramStatus",
                "UpdateDate" = now()
		 	  WHERE 
	            "Identifier" = "paramIdentifier"
$BODY$;

ALTER FUNCTION public.updateboletopaymentstatusbyidentifier(character varying, integer)
    OWNER TO "OSB";