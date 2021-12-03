CREATE OR REPLACE FUNCTION public.insertoperation(    
    "paramCreationUserId" bigint,
    "paramUpdateUserId" bigint
)
    RETURNS TABLE("OperationId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Operation"(
     "CreationDate",
     "UpdateDate",
	 "CreationUserId",
	 "UpdateUserId"
    )
	VALUES (
         Now(),
         Now(), 
         "paramCreationUserId",
         "paramUpdateUserId"
) RETURNING "OperationId";	
$BODY$;

ALTER FUNCTION public.insertoperation(bigint, bigint)
    OWNER TO "osb";