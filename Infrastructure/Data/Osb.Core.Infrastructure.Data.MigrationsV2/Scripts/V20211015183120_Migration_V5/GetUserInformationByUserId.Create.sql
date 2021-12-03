-- FUNCTION: public.getuserinformationbyuserid(bigint)

-- DROP FUNCTION public.getuserinformationbyuserid(bigint);

CREATE OR REPLACE FUNCTION public.getuserinformationbyuserid(
	"paramUserId" bigint)
    RETURNS TABLE("UserInformationId" bigint, "Name" text, "Mail" text, "CellPhone" text, "ZipCode" text, "Street" text, "Number" text, "District" text, "Complement" text, "City" text, "State" text, "UserId" bigint, "CreationUserId" bigint, "UpdateUserId" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 	"UserInformationId",
		"Name",
		"Mail",
		"CellPhone",
		"ZipCode",
		"Street",
		"Number",
		"District",
		"Complement",
		"City",
		"State",
		"UserId",
		"CreationUserId",
		"UpdateUserId",
		"CreationDate",
		"UpdateDate",
		"DeletionDate"
	FROM public."UserInformation"
    WHERE
        ("UserId" = "paramUserId")
        AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getuserinformationbyuserid(bigint)
    OWNER TO "osb";
