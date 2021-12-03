CREATE OR REPLACE FUNCTION public.insertuseraccount(
	"paramAccountId" bigint,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserAccount"
                    (
	                 "AccountId",			
					 "UserId",
					 "CreationDate",
					 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId")
	VALUES (
		   "paramAccountId",
		   "paramUserId",
		   CURRENT_DATE,
           CURRENT_DATE,
           '1',
		   '1')
$BODY$;

ALTER FUNCTION public.insertuseraccount(bigint, bigint)
    OWNER TO "osb";
