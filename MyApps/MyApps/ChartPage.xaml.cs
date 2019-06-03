using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace MyApps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : ContentPage
	{
        List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Label = "Red",
                ValueLabel = "200",
                Color = SKColor.Parse("#FF0000")
            },
            new Entry(250)
            {
                Label = "Green",
                ValueLabel = "250",
                Color = SKColor.Parse("#00FF00")
            },
            new Entry(100)
            {
                Label = "Blue",
                ValueLabel = "100",
                Color = SKColor.Parse("#0000FF")
            }
        };

        public ChartPage ()
		{
			InitializeComponent ();
            chartView.Chart = new DonutChart() { Entries = entries };
        }
	}
}