CREATE OR REPLACE FUNCTION public.insertsubaccount(
	"paramAccountId" bigint,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying)
    RETURNS TABLE("SubAccountId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."SubAccount"(
					"AccountId",
					"Bank",
					"BankBranch",
					"BankAccount",
					"BankAccountDigit",
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId")
			VALUES (
					"paramAccountId",
					"paramBank",
					"paramBankBranch",
					"paramBankAccount",
					"paramBankAccountDigit",
					Now(),
					Now(),
					1,
					1) RETURNING "SubAccountId";
$BODY$;

ALTER FUNCTION public.insertsubaccount(bigint, character varying, character varying, character varying, character varying)
    OWNER TO "OSB";
