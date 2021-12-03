CREATE OR REPLACE FUNCTION public.updateuser(
	"paramUserId" bigint,
	"paramLogin" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramCellPhone" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."User"
			  SET
	             "Login" = "paramLogin",			
				 "Name" = "paramName",
				 "Mail" = "paramMail",
				 "CellPhone" = "paramCellPhone",
				 "UpdateDate" = CURRENT_DATE,
				 "UpdateUserId" = '1'
		 	  WHERE 
			  	  "DeletionDate" IS NULL AND
			  	  "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuser(bigint, character varying, character varying, character varying, character varying)
    OWNER TO "osb";
