--DROP FUNCTION public.insertauthorizationtoken(bigint, bigint, character varying, character varying, timestamp without time zone, smallint);

CREATE OR REPLACE FUNCTION public.insertauthorizationtoken(	
	"paramUserId" bigint,
	"paramAccountId" bigint,		   
	"paramCode" character varying,
	"paramSalt" character varying,
	"paramExpirationDate" timestamp without time zone,
	"paramStatus" smallint)
  RETURNS void
  LANGUAGE 'sql'
  COST 100
  VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."AuthorizationToken"
	(
	"UserId",
	"AccountId",					 
	"Code",
	"Salt",
	"ExpirationDate",
	"Status",
	"CreationDate",
	"UpdateDate",
	"CreationUserId",
	"UpdateUserId")
VALUES (
	"paramUserId",
    "paramAccountId",		   
	"paramCode",
	"paramSalt",
	"paramExpirationDate",
	"paramStatus",
	NOW(),
    NOW(),
    '1',
	'1')
$BODY$;

ALTER FUNCTION public.insertauthorizationtoken(bigint, bigint, character varying, character varying, timestamp without time zone, smallint)
    OWNER TO "osb";