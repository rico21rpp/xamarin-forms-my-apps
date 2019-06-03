using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnBtnChartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChartPage());
        }

        async void OnBtnCalculatorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalculatorPage());
        }

        async void OnBtnSoftwareClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SoftwarePage());
        }
    }
}
