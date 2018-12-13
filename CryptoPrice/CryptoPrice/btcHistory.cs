using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

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

            var url = "https://apiv2.bitcoinaverage.com/indices/global/history/" + currency + "EUR?period=alltime&format=json";
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(responseString);

                for (int i=0; i < 7; i++)
                {
                    string date = data[i].time;
                    string price = data[i].average;
                    dates[i] = date.Trim().Substring(0, 10);
                    prices[i] = price;
                }
            }

        }
    }
}
