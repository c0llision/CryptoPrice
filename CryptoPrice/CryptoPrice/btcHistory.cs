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
        private int NUM_DAYS = 7;
        public string currency = "BTC";
        public string[] dates = new string[NUM_DAYS];
        public string[] prices = new string[NUM_DAYS];

        public void update()
        {
            
        }
    }
}
