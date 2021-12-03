CREATE OR REPLACE FUNCTION public.insertuser(
	"paramLogin" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramCellPhone" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."User"
                    (
	                 "Login",			
					 "Name",
					 "Mail",
				     "CellPhone",
					 "CreationDate",
					 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId")
	VALUES (
		   "paramLogin",
		   "paramName",
		   "paramMail",
		   "paramCellPhone",
		   CURRENT_DATE,
           CURRENT_DATE,
           '1',
		   '1')
$BODY$;

ALTER FUNCTION public.insertuser(character varying, character varying, character varying, character varying)
    OWNER TO "OSB";
