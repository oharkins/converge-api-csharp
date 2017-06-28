using System;
using oharkins.ConvergAPI;

namespace Examples
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            TokenClass.TokenRequest TR = new TokenClass.TokenRequest()
			{
				ssl_merchant_id = "008092",
				ssl_user_id = "webpage",
				ssl_pin = "UZ0I5F",
				ssl_test_mode = true,
				ssl_card_number = "4111111111111111",
				ssl_exp_date = "1225",
				ssl_first_name = "Odis",
				ssl_last_name = "Harkins",
				ssl_cvv2cvc2 = "123"
			};
            var responce = new TokenClass.TokenResponse();

            TokenClass TC = new TokenClass();

            TC.GetToken(TR);


            //Console.WriteLine("Hello World!");
            SaleClass.SaleRequest SR = new SaleClass.SaleRequest()
            {
                ssl_merchant_id = "008092",
                ssl_user_id = "webpage",
                ssl_pin = "UZ0I5F",
                ssl_test_mode = true,
                ssl_amount = "10.00",
                ssl_card_number = "4124939999999990",
                ssl_exp_date = "1219",
                ssl_cvv2cvc2 = "123",
                ssl_avs_zip = "12345",
                ssl_verify = "Y"

            };

            var response = new SaleClass.SaleResponse();

            SaleClass SC = new SaleClass();

            response = SC.MakeSale(SR);
            Console.WriteLine(response.errorMessage);
            Console.WriteLine(response.errorCode);
            Console.WriteLine(response.errorName);
        }
    }
}
