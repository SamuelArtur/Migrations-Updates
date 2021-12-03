-- FUNCTION: public.insertbankingdata(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer)

-- DROP FUNCTION public.insertbankingdata(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION public.insertbankingdata(
	"paramAccountId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramBankAccountType" integer)
    
    RETURNS TABLE("BankingDataId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."BankingData"(
    "AccountId",
    "TaxId",
    "Name",
    "Bank",
    "BankBranch",
    "BankAccount",
    "BankAccountDigit",
    "AccountType",
    "CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId")

	VALUES (
        "paramAccountId",
        "paramTaxId",
        "paramName",
        "paramBank",
        "paramBankBranch",
        "paramBankAccount",
        "paramBankAccountDigit",
        "paramBankAccountType", 
        CURRENT_DATE,
        CURRENT_DATE,
        1,
        1) RETURNING "BankingDataId";
$BODY$;

ALTER FUNCTION public.insertbankingdata(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer)
    OWNER TO "OSB";
