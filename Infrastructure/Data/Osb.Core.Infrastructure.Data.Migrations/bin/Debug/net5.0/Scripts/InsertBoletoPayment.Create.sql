--DROP FUNCTION public.insertboletopayment(bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, numeric, timestamp without time zone, timestamp without time zone, numeric, character varying, character varying);

CREATE OR REPLACE FUNCTION public.insertboletopayment("paramUserId" bigint, "paramAccountId" bigint, "paramBankingDataId" bigint, "paramName" character varying, "paramTaxId" character varying, "paramReceiverName" character varying, "paramReceiverTaxId" character varying, "paramPayerName" character varying, "paramPayerTaxId" character varying, "paramOperationType" integer, "paramStatus" integer, "paramBarcode" character varying, "paramPaymentValue" numeric, "paramPaymentDate" timestamp without time zone,"paramDueDate" timestamp without time zone, "paramDiscountValue" numeric, "paramDescription" character varying, "paramIdentifier" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."BoletoPayment"
                    (
                     "UserId",
                     "AccountId",
                     "BankingDataId", 
                     "Name",                     
                     "TaxId",
                     "ReceiverName",
                     "ReceiverTaxId",
                     "PayerName",
                     "PayerTaxId",
                     "OperationType", 
                     "Status",
                     "Barcode",
                     "PaymentValue", 
                     "PaymentDate", 
                     "DueDate", 
                     "DiscountValue",
                     "Description",
                     "Identifier", 
                     "CreationDate",
                     "UpdateDate",
                     "CreationUserId",
                     "UpdateUserId")
    VALUES (
            "paramUserId",
            "paramAccountId",
            "paramBankingDataId",
            "paramName",
            "paramTaxId", 
            "paramReceiverName",
            "paramReceiverTaxId",
            "paramPayerName",
            "paramPayerTaxId",
            "paramOperationType",
            "paramStatus",
            "paramBarcode",
            "paramPaymentValue",
            "paramPaymentDate",
            "paramDueDate",
            "paramDiscountValue",
            "paramDescription",
            "paramIdentifier",
            NOW(),
            NOW(),
            "paramUserId",
            "paramUserId")
$BODY$;

ALTER FUNCTION public.insertboletopayment(bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, numeric, timestamp without time zone, timestamp without time zone, numeric, character varying, character varying);
    OWNER TO "OSB";