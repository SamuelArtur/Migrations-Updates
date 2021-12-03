CREATE OR REPLACE FUNCTION public.insertinactivatecard(
	"paramIdentifierCard" character varying,
	"paramAccountId" bigint,
	"paramPin" character varying,
	"paramSalt" character varying,
	"paramReasonCode" integer,
	"paramStatus" integer,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InactivateCard"
                    (
	                 "IdentifierCard",
					 "AccountId",
					 "Pin",
					 "Salt",
				     "ReasonCode",
					 "Status",
					 "CreationDate",
    				 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId")
			 VALUES (
					 "paramIdentifierCard",
				 	 "paramAccountId",
					 "paramPin",
					 "paramSalt",
					 "paramReasonCode",
					 "paramStatus",
			 		 Now(),
			 	     Now(),
			 		 "paramUserId",
			 		 "paramUserId")
$BODY$;

ALTER FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint)
    OWNER TO postgres;

GRANT EXECUTE ON FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint) TO "OSB" WITH GRANT OPTION;

GRANT EXECUTE ON FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint) TO PUBLIC;

GRANT EXECUTE ON FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint) TO PUBLIC;

GRANT EXECUTE ON FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint) TO postgres;

GRANT EXECUTE ON FUNCTION public.insertinactivatecard(character varying, bigint, character varying, character varying, integer, integer, bigint) TO postgres;
