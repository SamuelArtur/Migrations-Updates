CREATE OR REPLACE FUNCTION public.updateinternaltransferstatustogenerated(
    "paramId" bigint,
    "paramStatus" int,
    "paramExternalIdentifier" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

UPDATE 
        public."InternalTransfer"
SET 
        "Status" = "paramStatus", 
        "ExternalIdentifier" = "paramExternalIdentifier",
        "UpdateDate" = now()
WHERE
        "InternalTransferId" = "paramId"

$BODY$;
ALTER FUNCTION public.updateinternaltransferstatustogenerated(bigint, int, bigint)
    OWNER TO "OSB";