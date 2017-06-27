using System;
using System.Net.Http;

namespace oharkins.ConvergAPI
{
    public class HttpService
    {
        private static readonly HttpClient client = new HttpClient();
        public static string PostItem(string xmldata)
        {

            var values = new System.Collections.Generic.Dictionary<string, string>
            {
               { "xmldata", xmldata}
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync("https://api.demo.convergepay.com/VirtualMerchantDemo/processxml.do", content);

            return response.Result.IsSuccessStatusCode.ToString();
        }
    }
}
