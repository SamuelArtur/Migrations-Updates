CREATE OR REPLACE FUNCTION public.getlimitedaccountlistbystatus(
	"paramStatus" integer)
    RETURNS TABLE("LimitedAccountId" bigint, "AccountId" bigint, "Name" character varying, "PhoneNumber" character varying, "TaxId" character varying, "Mail" character varying, "Nickname" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "BirthDate" timestamp without time zone, "TradingName" character varying, "LegalName" character varying, "ConstitutionDate" timestamp without time zone, "Status" integer, "Attempts" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "LimitedAccountId",
        "AccountId",
        "Name",
        "PhoneNumber",
        "TaxId",
        "Mail",
        "Nickname",
        "Bank",
        "BankBranch",
        "BankAccount",
        "BankAccountDigit",
        "BirthDate",
        "TradingName",
        "LegalName",
        "ConstitutionDate",
        "Status",
        "Attempts",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."LimitedAccount"
WHERE "Status" = "paramStatus"
$BODY$;

ALTER FUNCTION public.getlimitedaccountlistbystatus(integer)
    OWNER TO "osb";