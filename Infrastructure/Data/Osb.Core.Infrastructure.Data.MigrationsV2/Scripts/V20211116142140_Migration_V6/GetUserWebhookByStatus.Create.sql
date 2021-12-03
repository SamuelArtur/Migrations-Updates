CREATE OR REPLACE FUNCTION public.getuserwebhookbystatus(
	"paramStatus" integer,
	"paramLimit" bigint)
    RETURNS TABLE("UserWebhookId" bigint, "BusinessUnitId" bigint, "Name" character varying, "Mail" character varying, "CellPhone" character varying, "UserTaxId" character varying, "AccountKey" character varying, "AccountTaxId" character varying, "AccountName" character varying, "Password" character varying, "AccountWebhookId" bigint, "AccountConditionType" integer, "AccountStatus" character varying, "PartnerId" bigint, "FromBank" character varying, "FromBankBranch" character varying, "FromBankAccount" character varying, "FromBankAccountDigit" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  UWH."UserWebhookId",
        UWH."CompanyId",        
        UWH."Name",
        UWH."Mail",
        UWH."CellPhone",           
        UWH."UserTaxId",      
        UWH."AccountKey",
		UWH."AccountTaxId",
		UWH."AccountName",
		UWH."Password",		
   		ACC."AccountWebhookId",
		ACC."AccountConditionType", 
   		ACC."AccountStatus",     	 
    	ACC."PartnerId",      	 
    	ACC."FromBank", 
    	ACC."FromBankBranch", 
    	ACC."FromBankAccount", 
    	ACC."FromBankAccountDigit" 		
    FROM
        "UserWebhook" AS UWH
        INNER JOIN "AccountWebhook" AS ACC ON ACC."AccountKey" = UWH."AccountKey"
    WHERE
        UWH."Status" = "paramStatus"
	AND ACC."Status" = "paramStatus"
	AND UWH."DeletionDate" IS NULL
	LIMIT "paramLimit";
$BODY$;

ALTER FUNCTION public.getuserwebhookbystatus(integer, bigint)
    OWNER TO "osb";

-- GRANT EXECUTE ON FUNCTION public.getuserwebhookbystatus(integer, bigint) TO "OSB" WITH GRANT OPTION;

-- GRANT EXECUTE ON FUNCTION public.getuserwebhookbystatus(integer, bigint) TO PUBLIC;

-- GRANT EXECUTE ON FUNCTION public.getuserwebhookbystatus(integer, bigint) TO postgres;