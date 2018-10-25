using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoPrice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            updatePrice();
        }
        
        public void updatePrice(string currency="BTC")
        {
            var client = new HttpClient();
            var priceUrl = "https://apiv2.bitcoinaverage.com/convert/global?from=" + currency + "&to=EUR&amount=1";
            var response = client.GetAsync(priceUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                dynamic priceData = JsonConvert.DeserializeObject(responseString);

                string price =  "€ " + priceData.price;
                lblPrice.Text = price;
            }

        }
    }
}