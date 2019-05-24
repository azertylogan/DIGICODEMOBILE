using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.Http;
using DIGICODE.ViewModels;
using DIGICODE.Services;

namespace DIGICODE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConnexionPage : ContentPage
	{

        //string connectionString = @"Server=172.20.244.7:34283;Database=logandoare;User Id=logandoare;Password=azertyFREE0304;Trusted_Connection=true";

        public ConnexionPage ()
		{
			InitializeComponent ();
		}

        async void OnConnexion(object sender, EventArgs e)
        {
            String result;
            var login = email.Text;
            var mdp = motdepasse.Text;
            try
            {

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("email", login));
                postData.Add(new KeyValuePair<string, string>("motdepasse", mdp));

                var content = new FormUrlEncodedContent(postData);

                HttpClient client = new HttpClient();

                //client.BaseAddress = new Uri("http://ftpperso.free.fr");
                client.BaseAddress = new Uri("http://files.000webhost.com");



                //var response = await client.PostAsync("http://logandoare.free.fr/WebApiCon.php", content);
                var response = await client.PostAsync("http://logandoare.000webhostapp.com/WebApiCon.php", content);
                result = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);

            

                if(Boolean.TryParse(result, out bool res))
                {
                    Console.WriteLine("yes");
                    if (res == true)
                    {
                        //MockDataStore.afficheSalles();
                        await Navigation.PushModalAsync(new MainPage());
                        
                    }
                    else {
                        await DisplayAlert("Connection impossible", "Vérifiez que vous êtes bien connecter à internet ! \nLe mot de passe et/ou l'identifiant peut être eronné !", "OK");
                        
                    }
                }
                else
                {
                    Console.WriteLine("erreur de connexion");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
                return;
            }
        }


        

      /*  public async void afficheSalles()
        {
            String result;



            var postData = new List<KeyValuePair<string, string>>();
            

            var content = new FormUrlEncodedContent(postData);

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://ftpperso.free.fr");



            var response = await client.PostAsync("http://logandoare.free.fr/JSON.php", content);
            result = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(result);
        }*/

        async void deco_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TrueMainPage());
        }
    }
}
 