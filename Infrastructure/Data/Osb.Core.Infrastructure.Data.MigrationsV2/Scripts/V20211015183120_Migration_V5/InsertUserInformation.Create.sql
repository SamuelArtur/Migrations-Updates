-- FUNCTION: public.insertuserinformation(text, text, text, text, text, text, text, text, text, text, bigint)

-- DROP FUNCTION public.insertuserinformation(text, text, text, text, text, text, text, text, text, text, bigint);

CREATE OR REPLACE FUNCTION public.insertuserinformation(
	"paramName" text,
	"paramMail" text,
	"paramCellPhone" text,
	"paramZipCode" text,
	"paramStreet" text,
	"paramNumber" text,
	"paramComplement" text,
	"paramDistrict" text,
	"paramCity" text,
	"paramState" text,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserInformation"(
	"Name", "Mail", "CellPhone", "ZipCode", "Street", "Number", "District", "Complement", "City", "State", "UserId", "CreationUserId", "UpdateUserId", "CreationDate", "UpdateDate")
	VALUES (
		"paramName",
        "paramMail",
        "paramCellPhone",
        "paramZipCode",
        "paramStreet",
        "paramNumber",
        "paramDistrict",
        "paramComplement",
        "paramCity",
        "paramState",
        "paramUserId",
        "paramUserId",
        "paramUserId",
        now(),
		now()
	);
$BODY$;

ALTER FUNCTION public.insertuserinformation(text, text, text, text, text, text, text, text, text, text, bigint)
    OWNER TO "osb";
