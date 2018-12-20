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
// Marcus Walsh
// g00291472

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
            // Loads portfolio values from class
            btcBal.Text = btcPortfolio.data.btcBal.ToString("N2");
            ltcBal.Text = btcPortfolio.data.ltcBal.ToString("N2");
            ethBal.Text = btcPortfolio.data.ethBal.ToString("N2");
            lblBal.Text = btcPortfolio.getBalance().ToString("N2");

            BalanceChanged();
        }

        public void save()
        {
            // Saves values to class and then to the file
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

        private void BalanceChanged()
        {
            // Recalculates portfolio value
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
            // Event handler for save button, saves portfolio values to file
            // and recalculates balances
            save();
            BalanceChanged();
        }
    }
}