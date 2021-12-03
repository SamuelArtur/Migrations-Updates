CREATE OR REPLACE FUNCTION public.updateuser(
	"paramUserId" bigint,
	"paramLogin" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramCellPhone" character varying,
	"paramStatus" integer,
	"paramLoginAttempts" integer,
	"paramUpdateUserId" bigint)
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
                 "Status" = "paramStatus",
				 "LoginAttempts" = "paramLoginAttempts",
                 "UpdateDate" = now(),
                 "UpdateUserId" = "paramUpdateUserId"
              WHERE
                  "DeletionDate" IS NULL AND
                  "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuser(bigint, character varying, character varying, character varying, character varying, integer, integer, bigint)
    OWNER TO "osb";