using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
    public partial class LivePrice : ContentPage
    {
        BitcoinPrice btcPrice = new BitcoinPrice();
        btcPortfolio btcPortfolio = new btcPortfolio();

        public LivePrice()
        {
            InitializeComponent();
            updatePrice();
        }

        private void updatePrice()
        {
            // Updates the price and portfolio displayed
            btcPrice.updatePrice();
            string price = "€ " + btcPrice.currentPrice;
            lblPrice.Text = price;

            lblPortfolio.Text = "€ " + btcPortfolio.getBalance().ToString("N2");
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            // Event handler which ensure the currency is set and updates
            // the price and portfolio
            int selectedIndex = pckCurrency.SelectedIndex;

            if (selectedIndex != -1)
            {
                btcPrice.currency = pckCurrency.Items[selectedIndex];
            }

            updatePrice();
        }
    }
}