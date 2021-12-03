CREATE OR REPLACE FUNCTION public.updateaccount(
	"paramAccountId" bigint,
	"paramCompanyId" bigint,
	"paramName" character varying,
	"paramStatus" bigint,
	"paramType" bigint,
	"paramSubAccountId" bigint,
	"paramTaxId" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."Account"
		SET                
	       "CompanyId" = "paramCompanyId",			
		   "Name" = "paramName",
		   "Status" = "paramStatus",
		   "Type" = "paramType",
		   "SubAccountId" = "paramSubAccountId",
		   "TaxId" =  "paramTaxId",
		   "UpdateDate" = CURRENT_DATE,
		   "UpdateUserId" = '1'
		 WHERE 
		 	 "DeletionDate" IS NULL AND
		     "AccountId" = "paramAccountId"
$BODY$;

ALTER FUNCTION public.updateaccount(bigint, bigint, character varying, bigint, bigint, bigint,character varying)
    OWNER TO "osb";
