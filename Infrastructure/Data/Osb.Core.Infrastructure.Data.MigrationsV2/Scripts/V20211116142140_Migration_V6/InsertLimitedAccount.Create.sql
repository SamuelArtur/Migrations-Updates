CREATE OR REPLACE FUNCTION public.insertlimitedaccount(
	"paramAccountId" bigint,
	"paramName" character varying,
	"paramPhoneNumber" character varying,
	"paramTaxId" character varying,
	"paramMail" character varying,
	"paramNickname" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramBirthDate" timestamp without time zone,
	"paramTradingName" character varying,
	"paramLegalName" character varying,
	"paramConstitutionDate" timestamp without time zone,
	"paramStatus" integer)
    RETURNS TABLE("LimitedAccountId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."LimitedAccount"
                    (
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
                    "CreationDate",
                    "UpdateDate",
                    "CreationUserId",
                    "UpdateUserId" 
                    )
	VALUES (
            "paramAccountId",
            "paramName",
            "paramPhoneNumber",
            "paramTaxId",
            "paramMail",
            "paramNickname",
            "paramBank",
            "paramBankBranch",
            "paramBankAccount",
            "paramBankAccountDigit",
            "paramBirthDate",
            "paramTradingName",
            "paramLegalName",
            "paramConstitutionDate",
            "paramStatus",
            NOW(),
            NOW(),
            1,
            1
           ) RETURNING "LimitedAccountId";
$BODY$;

ALTER FUNCTION public.insertlimitedaccount(bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, timestamp without time zone, character varying, character varying, timestamp without time zone, integer)
    OWNER TO "osb";