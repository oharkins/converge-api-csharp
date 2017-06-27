using System;
namespace oharkins.ConvergAPI
{
    public class TransactionClass
    {
        public TransactionClass()
        {
        }
		public class ConvergeTransaction
		{
			public string ssl_merchant_id { get; set; }
			public string ssl_user_id { get; set; }
			public string ssl_pin { get; set; }
			public bool ssl_test_mode { get; set; }

			//NOT SURE WHERE IT GOES DOWN THE LINE:
			public bool ssl_cvv2cvc2_indicator { get; set; }
		}
    }
}
