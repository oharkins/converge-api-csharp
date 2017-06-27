using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace oharkins.ConvergAPI
{
    public class HttpService
    {
        private static readonly HttpClient client = new HttpClient();
        public static string PostItem(string xmldata)
        {

            try
            {
                string responseString = Task.Run(() => MakeXMLCallAsync(xmldata)).Result;

                return responseString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //throw;
            }
            return "BAD";
        }

        public static async Task<string> MakeXMLCallAsync(string xmldata)
        {
            string body = "";
            var values = new System.Collections.Generic.Dictionary<string, string>
            {
               { "xmldata", xmldata}
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync("https://api.demo.convergepay.com/VirtualMerchantDemo/processxml.do", content);
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();

            }
            return body;
        }
    }
}
