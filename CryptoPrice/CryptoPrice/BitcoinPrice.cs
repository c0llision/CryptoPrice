using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace CryptoPrice
{
    class BitcoinPrice
    {
        private HttpClient client = new HttpClient();
        public int currentPrice = 99999;

        public void updatePrice(string currency="BTC")
        {
            var priceUrl = "https://apiv2.bitcoinaverage.com/convert/global?from=" + currency + "&to=EUR&amount=1";
            var response = client.GetAsync(priceUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic priceData = JsonConvert.DeserializeObject(responseString);

                currentPrice = priceData.price;
            }

        }
    }
}
