DROP FUNCTION insertuser(character varying,character varying,character varying,character varying);

CREATE OR REPLACE FUNCTION public.insertuser(
	"paramLogin" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramCellPhone" character varying)
    RETURNS TABLE("UserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

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
		   now(),
           now(),
           '1',
		   '1')RETURNING "UserId"
$BODY$;

ALTER FUNCTION public.insertuser(character varying, character varying, character varying, character varying)
    OWNER TO "osb";