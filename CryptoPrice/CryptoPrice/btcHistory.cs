using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
    class btcHistory
    {
        private HttpClient client = new HttpClient();
        public string currency = "BTC";
        public string[] dates = new string[7];
        public string[] prices = new string[7];

        public void update()
        {
            // Query the API for the historical price data

            var url = "https://apiv2.bitcoinaverage.com/indices/global/history/" + currency + "EUR?period=alltime&format=json";
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(responseString);

                // Format the values and store them on the arrays
                for (int i=0; i < 7; i++)
                {
                    string date = data[i].time;
                    float price = data[i].average;
                    dates[i] = date.Trim().Substring(0, 10);
                    prices[i] = price.ToString("N2");
                }
            }

        }
    }
}
