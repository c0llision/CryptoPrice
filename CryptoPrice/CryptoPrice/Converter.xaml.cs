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
		}

        private void updateConversion(object sender, TextChangedEventArgs e)
        {
            btcConvert.amount = txtFrom.Text;
        }
    }
}