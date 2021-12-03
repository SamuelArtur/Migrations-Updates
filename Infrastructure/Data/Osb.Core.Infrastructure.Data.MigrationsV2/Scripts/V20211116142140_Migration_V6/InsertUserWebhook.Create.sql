CREATE OR REPLACE FUNCTION public.insertuserwebhook(
	"paramCompanyId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramCellPhone" character varying,
	"paramAccountName" character varying,
	"paramAccountTaxId" character varying,
	"paramStatus" integer,
	"paramEventType" bigint,
	"paramUserTaxId" character varying,
	"paramAccountKey" character varying,
	"paramPassword" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserWebhook"
                    (
					 "CompanyId",
                     "TaxId",           
                     "Name",
                     "Mail",
                     "CellPhone",
                     "AccountName",
                     "AccountTaxId",
                     "Status",
                     "EventType",
                     "UserTaxId",
                     "AccountKey",
                     "Password",
                     "CreationDate",
                     "UpdateDate",
                     "CreationUserId",
                     "UpdateUserId")
             VALUES (
				 	"paramCompanyId",
                    "paramTaxId",
                    "paramName",
                    "paramMail",
                    "paramCellPhone",
                    "paramAccountName", 
                    "paramAccountTaxId",
                    "paramStatus", 
                    "paramEventType",
				 	"paramUserTaxId",
                    "paramAccountKey",
                    "paramPassword",
                     Now(),
                     Now(),
                     '1',
                     '1');
$BODY$;

ALTER FUNCTION public.insertuserwebhook(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer, bigint, character varying, character varying, character varying)
    OWNER TO "osb";