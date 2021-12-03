CREATE OR REPLACE FUNCTION public.insertoutputlog(
	"paramResponse" text)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."OutputLog" (
	"Response",
	"LogDate",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId",
	"UpdateUserId")
VALUES (        		 
   "paramResponse",
	Now(),
	Now(),
	Now(),
	Now(),
	1,
	1)
$BODY$;

ALTER FUNCTION public.insertoutputlog(text)
    OWNER TO "OSB";