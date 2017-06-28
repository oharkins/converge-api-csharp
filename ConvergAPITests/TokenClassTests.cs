using Microsoft.VisualStudio.TestTools.UnitTesting;
using oharkins.ConvergAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oharkins.ConvergAPI.Tests
{
    [TestClass()]
    public class TokenClassTests
    {
        [TestMethod()]
        public void GetTokenTest()
        {
            TokenClass.TokenRequest TR = new TokenClass.TokenRequest()
            {
                ssl_merchant_id = "008092",
                ssl_user_id = "webpage",
                ssl_pin = "UZ0I5F",
                ssl_test_mode = true,
                ssl_card_number = "4124939999999990",
                ssl_exp_date = "1225",
                ssl_first_name = "Odis",
                ssl_last_name = "Harkins",
                ssl_cvv2cvc2 = "123",
                ssl_avs_zip = "12345",
                ssl_verify = "Y"
            };

            var responce = new TokenClass.TokenResponse();

            TokenClass TC = new TokenClass();

            responce = TC.GetToken(TR);

            Assert.AreEqual(responce.ssl_token_response, "SUCCESS");
            Assert.AreEqual("APPROVAL", responce.ssl_result_message);
        }
    }
}