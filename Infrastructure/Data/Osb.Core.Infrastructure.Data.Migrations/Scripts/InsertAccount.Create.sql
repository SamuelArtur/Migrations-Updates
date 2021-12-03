CREATE OR REPLACE FUNCTION public.insertaccount(
	"paramCompanyId" bigint,
	"paramBankingDataId" bigint,
	"paramName" character varying,
	"paramStatus" bigint,
	"paramType" bigint,
	"paramTaxId" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Account"
                    (
	                 "CompanyId",
					 "BankingDataId",
					 "Name",
					 "Status",
				     "Type",
					 "TaxId",
					 "CreationDate",
					 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId")
	VALUES (
		   "paramCompanyId",
		   "paramBankingDataId",
		   "paramName",
		   "paramStatus",
		   "paramType",
		   "paramTaxId",
		   CURRENT_DATE,
           CURRENT_DATE,
           '1',
		   '1')
$BODY$;

ALTER FUNCTION public.insertaccount(bigint, bigint, character varying, bigint, bigint, character varying)
    OWNER TO "OSB";
