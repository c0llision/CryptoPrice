using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Reflection;

namespace CryptoPrice
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

    public class PortfolioFile
    {
        public float btcBal  { get; set; }
        public float ltcBal  { get; set; }
        public float ethBal  { get; set; }
    }

    public partial class Portfolio : ContentPage
	{
        btcConvert btcConvert = new btcConvert();
        btcPortfolio btcPortfolio = new btcPortfolio();

		public Portfolio ()
		{
			InitializeComponent ();
            load();
		}

        public void load()
        {
            btcBal.Text = btcPortfolio.data.btcBal.ToString("N2");
            ltcBal.Text = btcPortfolio.data.ltcBal.ToString("N2");
            ethBal.Text = btcPortfolio.data.ethBal.ToString("N2");
            lblBal.Text = btcPortfolio.getBalance().ToString("N2");

            BalanceChanged();
        }

        public void save()
        {
            float amount;

            if (float.TryParse(btcBal.Text, out amount))
            {
                btcPortfolio.data.btcBal = amount; 
            }

            if (float.TryParse(ltcBal.Text, out amount))
            {
                btcPortfolio.data.ltcBal = amount; 
            }

            if (float.TryParse(ethBal.Text, out amount))
            {
                btcPortfolio.data.ethBal = amount; 
            }

            btcPortfolio.saveFile();


        }
        private void ReadLocalData()
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

                // Create the stream based on the file
                Stream stream = assembly.GetManifestResourceStream("CryptoPrice.Data.portfolio.json");
                // Create the reader and read the text
                using (var reader = new StreamReader(stream))
                {
                    // Read all the text as a block
                    fileText = reader.ReadToEnd();

                }
            }

            PortfolioFile portfolio = JsonConvert.DeserializeObject<PortfolioFile>(fileText);
            btcBal.Text = portfolio.btcBal.ToString("N2");
            ltcBal.Text = portfolio.ltcBal.ToString("N2");
            ltcBal.Text = portfolio.ethBal.ToString("N2");

            BalanceChanged();
        }


        private void BalanceChanged()
        {
            float balance;
            float amount;
            amount = btcConvert.convertCurrency("BTC", "EUR", btcBal.Text);
            lblBtc.Text = "BTC Value: " + amount.ToString("N2");
            balance = amount;

            amount = btcConvert.convertCurrency("LTC", "EUR", ltcBal.Text);
            lblLtc.Text = "LTC Value: " + amount.ToString("N2");
            balance += amount;

            amount = btcConvert.convertCurrency("ETH", "EUR", ethBal.Text);
            lblEth.Text = "ETH Value: " + amount.ToString("N2");
            balance += amount;

            lblBal.Text = balance.ToString("N2");

        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            /*
            PortfolioFile portfolio = new PortfolioFile
            {
                btcBal = float.Parse(btcBal.Text),
                ltcBal = float.Parse(ltcBal.Text),
                ethBal = float.Parse(ethBal.Text),
            };

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string filename = Path.Combine(path, "portfolio.json");

            using (var streamWriter = new StreamWriter(filename, false))
            {
                string jsonText = JsonConvert.SerializeObject(portfolio);
                streamWriter.WriteLine(jsonText);
            }
            */
            save();
            BalanceChanged();

            //load();
        }
    }
}