CREATE OR REPLACE FUNCTION public.insertaccountwebhook(
	"paramAccountConditionType" integer,
	"paramAccountStatus" bigint,
	"paramAccountKey" character varying,
	"paramAccountCreationDate" timestamp with time zone,
	"paramAccountConditionId" bigint,
	"paramPartnerId" bigint,
	"paramBusinessUnitId" bigint,
	"paramIdentifier" bigint,
	"paramTaxNumber" character varying,
	"paramFromBank" character varying,
	"paramFromBankBranch" character varying,
	"paramFromBankAccount" character varying,
	"paramFromBankAccountDigit" character varying,
	"paramSendDate" timestamp with time zone,
	"paramToBank" character varying,
	"paramToBankBranch" character varying,
	"paramToBankAccount" character varying,
	"paramToBankAccountDigit" character varying,
	"paramMethod" character varying,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."AccountWebhook" (		
		 "AccountConditionType",
		 "AccountStatus",
		 "AccountKey",
		 "AccountCreationDate",
		 "AccountConditionId",
		 "PartnerId",
		 "BusinessUnitId",
		 "Identifier",
		 "TaxNumber",
		 "FromBank",
		 "FromBankBranch",
		 "FromBankAccount",
		 "FromBankAccountDigit",
	     "SendDate",
	     "ToBank",
		 "ToBankBranch",
		 "ToBankAccount",
		 "ToBankAccountDigit",
	     "Method",
	     "Status",
		 "CreationDate",
		 "UpdateDate",
		 "CreationUserId",
		 "UpdateUserId")
VALUES (
		 "paramAccountConditionType",
		 "paramAccountStatus",
		 "paramAccountKey",
	     "paramAccountCreationDate",
	     "paramAccountConditionId",
	     "paramPartnerId",
	     "paramBusinessUnitId",
	     "paramIdentifier",
	     "paramTaxNumber",		 
		 "paramFromBank",
		 "paramFromBankBranch",
		 "paramFromBankAccount",
		 "paramFromBankAccountDigit",
		 "paramSendDate",	
		 "paramToBank",
		 "paramToBankBranch",
		 "paramToBankAccount",
		 "paramToBankAccountDigit",
		 "paramMethod",
		 "paramStatus",
	     now(),
		 now(),
		 '1',
		 '1')
$BODY$;
ALTER FUNCTION public.insertaccountwebhook(integer, bigint, character varying, timestamp with time zone, bigint, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, timestamp with time zone, character varying, character varying, character varying, character varying, character varying, integer)
    OWNER TO "osb";