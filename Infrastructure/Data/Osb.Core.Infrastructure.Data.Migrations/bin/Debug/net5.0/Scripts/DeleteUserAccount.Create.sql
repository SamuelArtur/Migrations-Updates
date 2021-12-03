CREATE OR REPLACE FUNCTION public.deleteuseraccount(
	"paramUserAccountId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Delete From public."UserAccount"
		 WHERE 
		 	 "DeletionDate" IS NULL AND
		     "UserAccountId" = "paramUserAccountId"
$BODY$;

ALTER FUNCTION public.deleteuseraccount(bigint)
    OWNER TO "OSB";
