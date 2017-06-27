using System;
namespace oharkins.ConvergAPI
{
    public class ConvergeTransaction
    {
        public string ssl_merchant_id { get; set; }
        public string ssl_user_id { get; set; }
        public string ssl_pin { get; set; }
        public bool ssl_test_mode { get; set; }
        //Error Response
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string errorName { get; set; }
    }
}
