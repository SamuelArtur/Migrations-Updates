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
     "OperationType",
     "CreationDate",
     "UpdateDate",
	 "CreationUserId",
	 "UpdateUserId"
    )
	VALUES (
         "paramOperationType"
         now(),
         now(), 
         "paramCreationUserId",
         "paramUpdateUserId"
) RETURNING "OperationId";	
$BODY$;

ALTER FUNCTION public.insertoperation(bigint, bigint)
    OWNER TO "OSB";