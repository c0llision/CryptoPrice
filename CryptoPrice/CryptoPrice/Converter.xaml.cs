using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            btcConvert.amount = txtFrom.Text;

            int fromIndex = pckCurrencyFrom.SelectedIndex;
            int toIndex = pckCurrencyTo.SelectedIndex;

            if  (fromIndex != -1 && toIndex != -1)
            {
                btcConvert.fromCurrency = pckCurrencyFrom.Items[fromIndex];
                btcConvert.toCurrency = pckCurrencyTo.Items[toIndex];
            }
            
            btcConvert.convert();

            txtTo.Text = btcConvert.convertAmount;

        }

        private void updateConversion(object sender, TextChangedEventArgs e)
        {
            update();
        }

    }
}