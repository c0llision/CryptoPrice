using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;

namespace CryptoPrice
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PriceHistory : ContentPage
	{
        btcHistory btcHistory = new btcHistory();

        string[] colours =  { "#ff0033", "#ff8000", "#ffe600", "#1ab34d", "#1a66ff", "#801ab3" , "#801ab3" };
		public PriceHistory ()
		{
			InitializeComponent ();
            update();

		}
        
        public void update()
        {
            int index = pckCurrency.SelectedIndex;

            if(index != -1)
            {
                btcHistory.currency = pckCurrency.Items[index];
            }

            btcHistory.update();

            List<Microcharts.Entry> entries = new List<Microcharts.Entry>() {  };

            for (int i = 0; i < 7; i++)
            {
                entries.Add(new Microcharts.Entry(float.Parse(btcHistory.prices[i]))
                {
                    Label = btcHistory.dates[i],
                    ValueLabel = btcHistory.prices[i],
                    Color = SkiaSharp.SKColor.Parse(colours[i]),
                });
            }

            barChart.Chart = new LineChart { Entries = entries };


            date1.Text = btcHistory.dates[0];
            date2.Text = btcHistory.dates[1];
            date3.Text = btcHistory.dates[2];
            date4.Text = btcHistory.dates[3];
            date5.Text = btcHistory.dates[4];
            date6.Text = btcHistory.dates[5];
            date7.Text = btcHistory.dates[6];

            price1.Text = "€ " + btcHistory.prices[0];
            price2.Text = "€ " + btcHistory.prices[1];
            price3.Text = "€ " + btcHistory.prices[2];
            price4.Text = "€ " + btcHistory.prices[3];
            price5.Text = "€ " + btcHistory.prices[4];
            price6.Text = "€ " + btcHistory.prices[5];
            price7.Text = "€ " + btcHistory.prices[6];
        }

        private void pckCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}