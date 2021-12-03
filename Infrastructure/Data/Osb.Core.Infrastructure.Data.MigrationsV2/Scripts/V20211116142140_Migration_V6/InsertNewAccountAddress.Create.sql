CREATE OR REPLACE FUNCTION public.insertnewaccountaddress(
	"paramNewAccountId" bigint,
	"paramAddressLine" character varying,
	"paramAddressLine2" character varying,
	"paramZipCode" character varying,
	"paramNeighborhood" character varying,
	"paramCityCode" character varying,
	"paramCityName" character varying,
	"paramState" character varying,
	"paramAddressType" integer,
	"paramCountry" character varying,
	"paramComplement" character varying)
    RETURNS TABLE("NewAccountAddressId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."NewAccountAddress"
                    (
                    "NewAccountId",
                    "AddressLine",
                    "AddressLine2",
                    "ZipCode",
                    "Neighborhood",
                    "CityCode",
                    "CityName",
                    "State",
                    "AddressType",
                    "Country",
                    "Complement",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId"
                    )
	VALUES (
            "paramNewAccountId",
            "paramAddressLine",
            "paramAddressLine2",
            "paramZipCode",
            "paramNeighborhood",
            "paramCityCode",
            "paramCityName",
            "paramState",
            "paramAddressType",
            "paramCountry",
            "paramComplement",
            NOW(),
            NOW(),
            NULL,
            1,
            1
           ) RETURNING "NewAccountAddressId";
$BODY$;

ALTER FUNCTION public.insertnewaccountaddress(bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying)
    OWNER TO "osb";