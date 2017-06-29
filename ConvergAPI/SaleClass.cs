/*
    $Author: Odis Harkins
    https://developer.elavon.com/#/api/eb6e9106-0172-4305-bc5a-b3ebe832f823.rcosoomi/versions/5180a9f2-741b-439c-bced-5c84a822f39b.rcosoomi/documents/?converge-integration-guide/book/transaction_types/credit_card/sale.html

*/
using System;
using System.Xml.Serialization;
using oharkins.ConvergAPI;

namespace oharkins.ConvergAPI
{
    public class SaleClass
    {
        public SaleResponse MakeSale(SaleRequest request)
        {
            string xmldata = XMLService.Serialize<SaleRequest>(request);

            string response = HttpService.PostItem(xmldata);

            SaleResponse classfullresponse = XMLService.Deserialize<SaleResponse>(response);

            if (classfullresponse.errorCode != null)
            {
                TransactionError ex = new TransactionError("Somtheing Went Wrong")
                {
                    errCode = classfullresponse.errorCode,
                    errMessage = classfullresponse.errorMessage,
                    errName = classfullresponse.errorName
                };
                throw ex;
            }

            return classfullresponse;
        }

        [XmlRoot(ElementName = "txn")]
        public class SaleRequest : ConvergeTransaction
        {
            public string ssl_transaction_type = "ccsale";
            public bool ssl_show_form = false; //Optional
            public string ssl_track_data { get; set; }
            public string ssl_card_number { get; set; }
            public string ssl_token { get; set; } //Required for hand-keyed transaction if card number is not sent.
            public string ssl_exp_date { get; set; }
            public string ssl_amount { get; set; } //Transaction Sale Amount. Number with 2 decimal places. This amount includes the Net amount and Sales Tax.
            public string ssl_pos_mode { get; set; } // Valid values are:01 - Manual Entry Only02 - Magnetically Swipe Capability03 - Proximity / Contactless Read Capability04 - EMV Chip Capability(Icc) - Contact Only(w/Magstripe05 - EMV Chip Capability (ICC) - Dual Interface (w/Magstripe)            
            public string ssl_recurring_id { get; set; }
            public string ssl_entry_mode { get; set; } // The transaction entry indicator to indicate how the track data was captured. https://developer.elavon.com/#/api/eb6e9106-0172-4305-bc5a-b3ebe832f823.rcosoomi/versions/5180a9f2-741b-439c-bced-5c84a822f39b.rcosoomi/documents/?converge-integration-guide/book/transaction_types/credit_card/sale.html
            public string ssl_card_present { get; set; } //Recommended to be passed on hand-keyed transactions to indicate if the card was present at the time of the transaction. Valid values: Y or N. Example: Card present of Y in hand-keyed retail and service environments.
            public string ssl_avs_zip { get; set; } //Cardholder ZIP code.
            public string ssl_avs_address { get; set; } //Recommended for hand-keyed transactions. Cardholder Address.
            public string ssl_enc_track_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from an Ingenico encrypting device. 
            public string ssl_encrypted_track1_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from a Magtek encrypting reader. 
            public string ssl_encrypted_track2_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from a Magtek encrypting reader. 
            public string ssl_ksn { get; set; } //Required when sending track data from an encrypting device for payment cards.
            public string ssl_verify { get; set; } //Account Verify indicator to indicate that account verification is needed prior to generating a token. Valid values: Y, N.
            public string ssl_cvv2cvc2 { get; set; } //The credit card security code is a three-digit or four-digit number, printed either on the back or the front of the card. 
            public string ssl_cvv2cvc2_indicator { get; set; } //The CVV2/CVC/CID indicator is one numeric value that should be passed with the CVV value (ssl_cvv2cvc2) to indicate if the CVV is present in the request.
            public string ssl_invoice_number { get; set; } //The invoice or ticket number. 
            public string ssl_description { get; set; } //The description, merchant defined value. 
            public string ssl_customer_code { get; set; } //The Customer Code or PO Number that appears on the cardholder’s credit card billing statement.
            public string ssl_salestax { get; set; }//Sales tax amount applied to this transaction in decimal. Tax exempt transactions can pass 0.00 to properly reflect a tax exempt transaction.
            public string ssl_tip_amount { get; set; } //Tip or gratuity amount to be added, must be 2 decimal places, can be 0.00 to reset or remove the original tip from a transaction. Example: 1.00.
            public string ssl_server { get; set; }//Use only in a Service market segment 
            public string ssl_shift { get; set; }//Use only in a Service market segment. 
            public string ssl_dynamic_dba { get; set; } //DBA Name provided by the merchant with each transaction. The maximum allowable Length of DBA Name variable provided by Merchant can be 21, 17 or 12 based on the length setup for the DBA constant in the field setup.
            public string ssl_partial_auth_indicator { get; set; } //The partial indicator flag must be sent to indicate that the application supports partial approval. 
            public string ssl_recurring_flag { get; set; }  //Use only when maintaining your own recurring and installment database.  The recurring flag must be sent to indicate if a credit card sale transaction is a recurring or an installment payment. 
            public string ssl_payment_number { get; set; } //Use only when maintaining your own recurring and installment database. 
            public string ssl_payment_count { get; set; } //Use only when maintaining your own recurring and installment database. Installment Count (total number of payments).
            public string ssl_transaction_currency { get; set; } //Transaction currency alphanumeric code must be included in the request to indicate the currency in which you wish to process. If omitted, the terminal default currency is assumed (for example: USD, CAD, and JPY). More than 94 currencies are supported. Refer to the ISO Currency Codes section for an extensive list of available currencies.
            public string ssl_get_token { get; set; } //Generate Token indicator, used to indicate if you wish to generate a token when passing card data. Valid value: Y (generate a token), N (do not generate token). Defaulted to N. 
            public string ssl_add_token { get; set; } // Add to Card Manager indicator, used to indicate if you wish to generate a token and store it in Card Manager. Valid value: Y (add token) , N (do not add token) Defaulted to N

        }
        [XmlRoot(ElementName = "txn")]
        public class SaleResponse : ConvergeTransaction
        {
            public string ssl_result { get; set; }
            public string ssl_result_message { get; set; }
            public string ssl_txn_id { get; set; }
            public string ssl_txn_time { get; set; }
            public string ssl_approval_code { get; set; }
            public string ssl_amount { get; set; }
            public string ssl_base_amount { get; set; }
            public string ssl_tip_amount { get; set; }
            public string ssl_requested_amount { get; set; }
            public string ssl_balance_due { get; set; }
            public string ssl_account_balance { get; set; }
            public string ssl_card_number { get; set; }
            public string ssl_avs_response { get; set; }
            public string ssl_cvv2_response { get; set; }
            public string ssl_invoice_number { get; set; }
            public string ssl_conversion_rate { get; set; }
            public string ssl_cardholder_currency { get; set; }
            public string ssl_cardholder_amount { get; set; }
            public string ssl_cardholder_base_amount { get; set; }
            public string ssl_cardholder_tip_amount { get; set; }
            public string ssl_server { get; set; }
            public string ssl_shift { get; set; }
            public string ssl_eci_ind { get; set; }
            public string ssl_transaction_currency { get; set; }
            public string ssl_card_short_description { get; set; }
            public string ssl_card_type { get; set; }
            public string ssl_token { get; set; }
            public string ssl_token_response { get; set; }
            public string ssl_add_token_response { get; set; }

        }
    }


   
}