using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
// Marcus Walsh
// g00291472

namespace CryptoPrice
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Graph : ContentPage
	{
        btcHistory btcHistory = new btcHistory();
        // This page is no longer used, the graph is on the History tab now
        // which is contains in PriceHistory.xaml

		public Graph ()
		{
			InitializeComponent ();
            update();
		}

        public void update()
        {
            btcHistory.update();

            List<Microcharts.Entry> entries = new List<Microcharts.Entry>() {  };

            for (int i = 0; i < 7; i++)
            {
                entries.Add(new Microcharts.Entry(float.Parse(btcHistory.prices[i]))
                {
                    Label = btcHistory.dates[i],
                    ValueLabel = btcHistory.prices[i],
                    Color = SkiaSharp.SKColor.Parse("#0000ff"),
                });
            }

            barChart.Chart = new LineChart { Entries = entries };

        }


        private void pckCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = pckCurrency.SelectedIndex;

            if(index != -1)
            {
                btcHistory.currency = pckCurrency.Items[index];
            }

            update();
        }

    }
}