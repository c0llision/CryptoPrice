using System;
using System.Collections.Generic;
using System.Linq;
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

            var btcPrice = new BitcoinPrice();
            updatePrice(btcPrice);
        }

        private void updatePrice(BitcoinPrice btcPrice)
        {
            btcPrice.updatePrice();
            string price = "€ " + btcPrice.currentPrice;
            lblPrice.Text = price;
        }

    }
}