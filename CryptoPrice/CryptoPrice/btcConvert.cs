using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
    class btcConvert
    {

        private HttpClient client = new HttpClient();
        public string fromCurrency = "eur";
        public string toCurrency = "btc";
        public string amount = "1";
        public string convertAmount = "1";

        public void convert()
        {
            convertAmount = convertCurrency(fromCurrency, toCurrency, amount).ToString("N2");
        }

        public float convertCurrency(string lFromCurrency, string lToCurrency, string lAmount)
        {
            // Use the API to convert the amount
            var priceUrl = "https://apiv2.bitcoinaverage.com/convert/global?from=" + lFromCurrency + "&to=" + lToCurrency + "&amount=" + lAmount;
            var response = client.GetAsync(priceUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic priceData = JsonConvert.DeserializeObject(responseString);

                return priceData.price;
            }

            // Something went wrong, probably can't access API, amount isn't a number, or currency pair invalid.
            return(0);

        }
    }
}
