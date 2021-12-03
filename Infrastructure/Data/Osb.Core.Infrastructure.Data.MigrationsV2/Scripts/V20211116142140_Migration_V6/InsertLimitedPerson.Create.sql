CREATE OR REPLACE FUNCTION public.insertlimitedperson(
	"paramLimitedAccountId" bigint,
	"paramName" character varying,
	"paramTaxNumber" character varying,
	"paramMail" character varying,
	"paramPhone" character varying,
	"paramPersonRoleType" integer,
	"paramBirthDate" timestamp without time zone)
    RETURNS TABLE("LimitedPersonId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."LimitedPerson"
                    (
                    "LimitedAccountId",
                    "Name",
                    "TaxNumber",
                    "Mail",
                    "Phone",
                    "PersonRoleType",
                    "BirthDate",
                    "CreationDate",
                    "UpdateDate",
                    "CreationUserId",
                    "UpdateUserId" 
                    )
	VALUES (
            "paramLimitedAccountId",
            "paramName",
            "paramTaxNumber",
            "paramMail",
            "paramPhone",
            "paramPersonRoleType",
            "paramBirthDate",
            NOW(),
            NOW(),
            1,
            1
           ) RETURNING "LimitedPersonId";
$BODY$;

ALTER FUNCTION public.insertlimitedperson(bigint, character varying, character varying, character varying, character varying, integer, timestamp without time zone)
    OWNER TO "osb";