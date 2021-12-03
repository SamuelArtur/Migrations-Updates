-- FUNCTION: public.updateuserinformation(bigint, text, text, text, text, text, text, text, text, text, text)

-- DROP FUNCTION public.updateuserinformation(bigint, text, text, text, text, text, text, text, text, text, text);

CREATE OR REPLACE FUNCTION public.updateuserinformation(
	"paramUserId" bigint,
	"paramName" text,
	"paramMail" text,
	"paramCellPhone" text,
	"paramZipCode" text,
	"paramStreet" text,
	"paramNumber" text,
	"paramDistrict" text,
	"paramComplement" text,
	"paramCity" text,
	"paramState" text)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."UserInformation"
SET "Name" = "paramName", 
	"Mail" = "paramMail", 
	"CellPhone" = "paramCellPhone", 
	"ZipCode" = "paramZipCode",
	"Street" = "paramStreet",
	"Number" = "paramNumber",
	"District" = "paramDistrict",
	"Complement" = "paramComplement",
	"City" = "paramCity",
	"State" = "paramState",
	"UpdateUserId" = "paramUserId",
	"UpdateDate" = now()
WHERE "UserId" = "paramUserId";
$BODY$;

ALTER FUNCTION public.updateuserinformation(bigint, text, text, text, text, text, text, text, text, text, text)
    OWNER TO "osb";
