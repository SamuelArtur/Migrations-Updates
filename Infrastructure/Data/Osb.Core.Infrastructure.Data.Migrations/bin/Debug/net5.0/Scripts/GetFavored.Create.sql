CREATE OR REPLACE FUNCTION public.getfavored(
    "paramAccountId" bigint,
    "paramTaxId" character varying,
    "paramBank" character varying,
    "paramBankBranch" character varying,
    "paramBankAccount" character varying,
    "paramType" integer)
    RETURNS TABLE("FavoredId" bigint, "AccountId" bigint, "TaxId" character varying, "Name" character varying, "Type" smallint, "BankName" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "CreationDate" timestamp with time zone, "UpdateDate" timestamp with time zone, "DeletionDate" timestamp with time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
       "FavoredId",
       "AccountId",
       "TaxId",
       "Name",
       "Type",
         "BankName",
       "Bank",
       "BankBranch",
       "BankAccount",
       "BankAccountDigit",
       "CreationDate",
       "UpdateDate",
       "DeletionDate",
       "CreationUserId",
       "UpdateUserId"
    FROM 
        public."Favored"
    WHERE
        ("paramAccountId" NOTNULL or "AccountId" = "paramAccountId")
    AND
        ("paramTaxId" ISNULL OR "TaxId" = "paramTaxId")
    AND
        ("paramBank" ISNULL OR "Bank" = "paramBank")
    AND
        ("paramBankBranch" ISNULL OR "BankBranch" = "paramBankBranch")
    AND
        ("paramBankAccount" ISNULL OR "BankAccount" = "paramBankAccount")
    AND
        ("paramType" ISNULL OR "Type" = "paramType")
    AND 
        "DeletionDate" IS NULL;
$BODY$;
ALTER FUNCTION public.getfavored(bigint, character varying, character varying, character varying, character varying, integer)
    OWNER TO "OSB";
    
    
  
  

