-- FUNCTION: public.insertbankingdata(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer)

-- DROP FUNCTION public.insertbankingdata(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION public.insertbankingdata(
	"paramName" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
    "CreationDate" timestamp without time zone,
	"UpdateDate" timestamp without time zone,
    "CreationUserId" timestamp without time zone,
    "UpdateUserId" timestamp without time zone
    )
    
    RETURNS TABLE("BankingDataId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."BankingData"(
    "Bank",
    "BankBranch",
    "BankAccount",
    "BankAccountDigit",
    "CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId")

	VALUES (
        "paramBank",
        "paramBankBranch",
        "paramBankAccount",
        "paramBankAccountDigit",
        CURRENT_DATE,
        CURRENT_DATE,
        1,
        1) RETURNING "BankingDataId";
$BODY$;

ALTER FUNCTION public.insertbankingdata(character varying, character varying, character varying, character varying, character varying, timestamp without time zone,timestamp without time zone,timestamp without time zone,timestamp without time zone)
    OWNER TO "osb";
