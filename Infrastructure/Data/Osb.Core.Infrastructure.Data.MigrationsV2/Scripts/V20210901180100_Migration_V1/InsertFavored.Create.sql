CREATE OR REPLACE FUNCTION public.insertfavored(
	"paramAccountId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramType" integer,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Favored"
                    (
					 "AccountId",
					 "TaxId",
					 "Name",
				     "Type",
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
		   "paramTaxId",
		   "paramName",
		   "paramType",
		   "paramBank",
		   "paramBankBranch",
		   "paramBankAccount",
		   "paramBankAccountDigit",
		   now(),
           now(),
           '1',
		   '1')
$BODY$;

ALTER FUNCTION public.insertfavored(bigint, character varying, character varying, integer, character varying, character varying, character varying, character varying)
    OWNER TO "osb";
