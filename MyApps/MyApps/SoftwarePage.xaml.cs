using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApps
{
    public class Software
    {
        public string Name { get; set; }
        public int Price { get; set; }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SoftwarePage : ContentPage
	{

        private const string Url = "https://www.enterkomputer.com/api/product/software.json";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Software> _softwares;

        public SoftwarePage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await _client.GetStringAsync(Url);
                    var softwares = JsonConvert.DeserializeObject<List<Software>>(content);

                    _softwares = new ObservableCollection<Software>(softwares);
                    softwareListView.ItemsSource = _softwares;


                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tERROR: {0}", e.Message);
            }
            base.OnAppearing();
        }
    }
}