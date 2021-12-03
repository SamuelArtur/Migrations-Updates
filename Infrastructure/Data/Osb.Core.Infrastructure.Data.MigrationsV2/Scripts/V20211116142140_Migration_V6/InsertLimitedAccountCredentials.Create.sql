CREATE OR REPLACE FUNCTION public.insertlimitedaccountcredentials(
	"paramLimitedAccountId" bigint,
	"paramPassword" character varying,
	"paramSalt" character varying)
    RETURNS TABLE("LimitedAccountCredentialId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."LimitedAccountCredential"
                    (
                    "LimitedAccountId",
                    "Password",
					"Salt",
                    "CreationDate",
                    "UpdateDate",
                    "CreationUserId",
                    "UpdateUserId" 
                    )
	VALUES (
            "paramLimitedAccountId",
            "paramPassword",
			"paramSalt",
            NOW(),
            NOW(),
            1,
            1
           ) RETURNING "LimitedAccountCredentialId";
$BODY$;

ALTER FUNCTION public.insertlimitedaccountcredentials(bigint, character varying, character varying)
    OWNER TO "osb";