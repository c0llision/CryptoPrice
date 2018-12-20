using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
    class BitcoinPrice
    {
        private HttpClient client = new HttpClient();
        public string currentPrice = "99999";
        public string currency = "BTC";

        public void updatePrice()
        {
            // Query the API for the latest price.
            var priceUrl = "https://apiv2.bitcoinaverage.com/convert/global?from=" + currency + "&to=EUR&amount=1";
            var response = client.GetAsync(priceUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic priceData = JsonConvert.DeserializeObject(responseString);

                // format it
                float i = priceData.price;
                currentPrice = i.ToString("N2");
            }

        }
    }
}
