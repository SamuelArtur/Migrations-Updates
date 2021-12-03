CREATE OR REPLACE FUNCTION public.insertaccount(
	"paramCompanyId" bigint,
	"paramAccountKey" character varying,
	"paramName" character varying,
	"paramType" bigint,
	"paramStatus" integer,
	"paramTaxId" character varying,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS TABLE("AccountId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."Account"
            (
	        "CompanyId",			
			"AccountKey",
			"Name",			
			"Type",
			"Status",		
			"TaxId",				
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramCompanyId",		  
		   "paramAccountKey",
		   "paramName",
		   "paramStatus",
		   "paramType",
		   "paramTaxId",
		   now(),
           now(),
           "paramCreationUserId",
		   "paramUpdateUserId") RETURNING "AccountId"
$BODY$;

ALTER FUNCTION public.insertaccount(bigint, character varying, character varying, bigint, integer, character varying, bigint, bigint)
    OWNER TO "osb";