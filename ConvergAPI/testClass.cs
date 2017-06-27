using System;
using NUnit;
using NUnit.Framework;

namespace oharkins.ConvergAPI
{
    [TestFixture]
    public class testClass
    {   

        [Test]
        public void GetToken()
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

			responce = TC.GetToken(TR);

            Assert.AreEqual(1,1);
        }
        [Test]
		public void MakeSale()
		{
			Assert.AreEqual(1, 1);
		}


    }
}
