using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DIGICODE.Models;
using DIGICODE.Views;
using DIGICODE.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;

namespace DIGICODE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void afficheSalles(object sender, SelectedItemChangedEventArgs args)
        {
            String json;
            var postData = new List<KeyValuePair<string, string>>();
            var content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ftpperso.free.fr");
            var response = await client.PostAsync("http://logandoare.free.fr/JSON.php", content);
            json = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
            RootObject s = JsonConvert.DeserializeObject<RootObject>(json);
            Console.WriteLine(s.M2LSalles[1].ville);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TrueMainPage());
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}