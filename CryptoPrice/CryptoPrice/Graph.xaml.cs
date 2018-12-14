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
	public partial class Graph : ContentPage
	{
		public Graph ()
		{
			InitializeComponent ();
            barChart.Chart = new BarChart { Entries = _entries };
		}

        private readonly List<Microcharts.Entry> _entries = new List<Microcharts.Entry>()
        {
            new Microcharts.Entry(200)
            {
                Label = "Mon",
                ValueLabel = "200",
                Color = SkiaSharp.SKColor.Parse("#0000ff"),
            },
            new Microcharts.Entry(210)
            {
                Label = "Mon",
                ValueLabel = "210",
                Color = SkiaSharp.SKColor.Parse("#0000ff"),
            },
            new Microcharts.Entry(120)
            {
                Label = "Mon",
                ValueLabel = "120",
                Color = SkiaSharp.SKColor.Parse("#0000ff"),
            },
            new Microcharts.Entry(100)
            {
                Label = "Mon",
                ValueLabel = "100",
                Color = SkiaSharp.SKColor.Parse("#0000ff"),
            },
        };
	}
}