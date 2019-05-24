using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using DIGICODE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DIGICODE.Services
{
    public class MockDataStore : IDataStore<Item>
    {
       
        List<Item> items;
        

        public MockDataStore()
        {
            afficheSalles();
            Console.WriteLine("*********************************");
            
        }
        
        public async void afficheSalles()
        {
            //json = @"{'M2LSalles':[{'id':'1','nom':'terrain de tennis','code':'4865A','typeSalle':'terrain exterieur','adresse':'5 rue azerty','codePostal':'48664','ville':'azerty','etage':'0'},{'id':'2','nom':'salle de formation','code':'6854A','typeSalle':'salle de formation','adresse':'68 boulevard qwerty','codePostal':'64858','ville':'qwert','etage':'3'}]}";
            String json;
            var postData = new List<KeyValuePair<string, string>>();
            var content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ftpperso.free.fr");
            var response = await client.PostAsync("http://logandoare.free.fr/JSON.php", content);
            json = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
            RootObject s = JsonConvert.DeserializeObject<RootObject>(json);
            Console.WriteLine(s.M2LSalles[1].code);


            items = new List<Item>();
            var mockItems = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), id = s.M2LSalles[0].id, nom = s.M2LSalles[0].nom, code = s.M2LSalles[0].code, typeSalle = s.M2LSalles[0].typeSalle, adresse = s.M2LSalles[0].adresse, codePostal = s.M2LSalles[0].codePostal, ville=s.M2LSalles[0].ville, etage = s.M2LSalles[0].etage },
                new Item { Id = Guid.NewGuid().ToString(), id = s.M2LSalles[1].id, nom = s.M2LSalles[1].nom, code = s.M2LSalles[1].code, typeSalle = s.M2LSalles[1].typeSalle, adresse = s.M2LSalles[1].adresse, codePostal = s.M2LSalles[1].codePostal, ville=s.M2LSalles[1].ville, etage = s.M2LSalles[1].etage },
            };

            
              //  mockItems += new Item { Id = Guid.NewGuid().ToString(), nom = rt.M2LSalles[i].nom };
            


           /* {

                new Item { Id = Guid.NewGuid().ToString(), nom = "First item", ville="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), nom = "Second item", ville="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), nom = "Third item", ville="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), nom = "Fourth item", ville="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), nom = "Fifth item", ville="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), nom = "Sixth item", ville="This is an item description." },
            };*/

            Console.WriteLine(s.M2LSalles[1].adresse);

            foreach (var item in mockItems)
                {
                    items.Add(item);
                }
            

            //foreach (Item s in items.data)
            //{
            //Console.WriteLine("\n*******************************************************************************\n" + s.adresse + "\n***************************************************");
            //}
        }

      


        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.id == item.id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}