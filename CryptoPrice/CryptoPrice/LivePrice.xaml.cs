using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoPrice
{
    public partial class LivePrice : ContentPage
    {
        BitcoinPrice btcPrice = new BitcoinPrice();

        public LivePrice()
        {
            InitializeComponent();

            updatePrice();
        }

        private void updatePrice()
        {
            btcPrice.updatePrice();
            string price = "€ " + btcPrice.currentPrice;
            lblPrice.Text = price;
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            int selectedIndex = pckCurrency.SelectedIndex;

            if (selectedIndex != -1)
            {
                btcPrice.currency = pckCurrency.Items[selectedIndex];
            }

            updatePrice();
        }
    }
}