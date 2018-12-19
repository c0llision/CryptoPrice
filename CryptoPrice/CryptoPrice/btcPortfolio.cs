using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Reflection;

namespace CryptoPrice
{
    class PortfolioData
    {
        public float btcBal  { get; set; }
        public float ltcBal  { get; set; }
        public float ethBal  { get; set; }
    }

    class btcPortfolio
    {
        btcConvert btcConvert = new btcConvert();

        public PortfolioData data = new PortfolioData
        {

            btcBal = 0,
            ltcBal = 0,
            ethBal = 0,
        };

        public btcPortfolio()
        {
            readFromFile();
        }

        private void readFromFile()
        {
            string fileText = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, "portfolio.json");

            try
            {
                using (var reader = new StreamReader(filename, false))
                {
                    fileText = reader.ReadToEnd();
                }
            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Portfolio)).Assembly;

                Stream stream = assembly.GetManifestResourceStream("CryptoPrice.Data.portfolio.json");
                using (var reader = new StreamReader(stream))
                {
                    fileText = reader.ReadToEnd();
                }
            }

            data = JsonConvert.DeserializeObject<PortfolioData>(fileText);
        }


        public void saveFile()
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string filename = Path.Combine(path, "portfolio.json");

            using (var streamWriter = new StreamWriter(filename, false))
            {
                string jsonText = JsonConvert.SerializeObject(data);
                streamWriter.WriteLine(jsonText);
            }
        }

        public float getBalance()
        {
            float balance;

            balance = btcConvert.convertCurrency("BTC", "EUR", data.btcBal.ToString("N2"));
            balance += btcConvert.convertCurrency("LTC", "EUR", data.ltcBal.ToString("N2"));
            balance += btcConvert.convertCurrency("ETH", "EUR", data.ethBal.ToString("N2"));
            return balance;
        }
    }
}
