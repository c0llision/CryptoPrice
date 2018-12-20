using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Converter : ContentPage
	{
        btcConvert btcConvert = new btcConvert();

		public Converter ()
		{
			InitializeComponent ();
            update();
		}

        public void update()
        {
            // Set the amount to the one in the entry box
            btcConvert.amount = txtFrom.Text;

            // Set the to/from currency to the values from the picker
            int fromIndex = pckCurrencyFrom.SelectedIndex;
            int toIndex = pckCurrencyTo.SelectedIndex;

            if  (fromIndex != -1 && toIndex != -1)
            {
                btcConvert.fromCurrency = pckCurrencyFrom.Items[fromIndex];
                btcConvert.toCurrency = pckCurrencyTo.Items[toIndex];
            }
            
            // Do the conversion and display the result
            btcConvert.convert();

            txtTo.Text = btcConvert.convertAmount;

        }

        private void updateConversion(object sender, TextChangedEventArgs e)
        {
            update();
        }

    }
}