using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

			TokenRequest TR = new TokenRequest()
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
			var bla = new GenerateToken();

			TokenResponse tkResp = bla.GetToken(TR);


        }
    }
}
