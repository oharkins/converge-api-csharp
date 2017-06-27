using System;
using System.Xml.Serialization;

namespace oharkins.ConvergAPI
{
    public class TokenClass
    {

        public TokenResponse GetToken(TokenRequest request)
        {
            string xmldata = XMLService.Serialize<TokenRequest>(request);

            string response = HttpService.PostItem(xmldata);

            TokenResponse classfullresponce = XMLService.Deserialize<TokenResponse>(response);

            return classfullresponce;
        }

        [XmlRoot(ElementName = "txn")]
        public class TokenRequest : ConvergeTransaction
        {
            public string ssl_transaction_type = "ccgettoken";
            public bool ssl_show_form = false; //Optional
            public string ssl_card_number { get; set; }
            public string ssl_exp_date { get; set; }
            public string ssl_recurring_id { get; set; }
            public string ssl_enc_track_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from an Ingenico encrypting device. 
            public string ssl_encrypted_track1_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from a Magtek encrypting reader. 
            public string ssl_encrypted_track2_data { get; set; } //Required for generating token using swiped or contactless (MSD) credit from a Magtek encrypting reader. 
            public string ssl_ksn { get; set; } //Required when sending track data from an encrypting device for payment cards.
            public string ssl_verify { get; set; } //Account Verify indicator to indicate that account verification is needed prior to generating a token. Valid values: Y, N.
            public string ssl_avs_zip { get; set; }
            public string ssl_avs_address { get; set; }
            public string ssl_cvv2cvc2 { get; set; } //The credit card security code is a three-digit or four-digit number, printed either on the back or the front of the card. 
            public string ssl_add_token { get; set; } // Add to Card Manager indicator, used to indicate if you wish to store the token generated in Card Manager. Valid value: Y (add token), N (do not add token) Defaulted to N 
            public string ssl_first_name { get; set; } //Required with Add to Card Manager indicator when generating a toke from card number. 
            public string ssl_last_name { get; set; } //Required with Add to Card Manager indicator when generating a toke from card number. 

        }
        [XmlRoot(ElementName = "txn")]
        public class TokenResponse : ConvergeTransaction
        {
            public string ssl_result { get; set; }
            public string ssl_result_message { get; set; }
            public string ssl_token { get; set; }
            public string ssl_token_response { get; set; }
            public string ssl_add_token_response { get; set; }
            public string ssl_txn_id { get; set; }
            public string ssl_txn_time { get; set; }
            public string ssl_avs_response { get; set; }
            public string ssl_cvv2_response { get; set; }
            public string ssl_approval_code { get; set; }
        }
    }
}
