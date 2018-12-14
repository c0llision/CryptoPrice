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
		}

        private readonly List<Microcharts.Entry> _entries = new List<Microcharts.Entry>()
        {
            new Microcharts.Entry(200)
            {
            }
        };
	}
}