CREATE OR REPLACE FUNCTION public.insertoutputlog(
	"paramResponse" text,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."OutputLog" (
	"Response",
	"CreationUserId",
	"LogDate")
VALUES (        		 
	"paramResponse",
	"paramUserId",
	now())
$BODY$;

ALTER FUNCTION public.insertoutputlog(text, bigint)
    OWNER TO "osb";
