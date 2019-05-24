using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DIGICODE.Models
{
    /* public class Salle
     {
         public List<Item> data;
     }

     public class Item
     {
         [JsonProperty(PropertyName = "id")]
         public string id { get; set; }

         [JsonProperty(PropertyName = "nom")]
         public string nom { get; set; }

         [JsonProperty(PropertyName = "code")]
         public string code { get; set; }

         [JsonProperty(PropertyName = "typesalle")]
         public string typeSalle { get; set; }

         [JsonProperty(PropertyName = "adresse")]
         public string adresse { get; set; }

         [JsonProperty(PropertyName = "codePostal")]
         public string codePostal { get; set; }

         [JsonProperty(PropertyName = "ville")]
         public string ville { get; set; }

         [JsonProperty(PropertyName = "etage")]
         public string etage { get; set; }



     }*/

    public class RootObject
    {
        public List<Item> M2LSalles { get; set; }
    }

    public class Item
    {
        public string Id { get; set; }
        public string id { get; set; }
        public string nom { get; set; }
        public string code { get; set; }
        public string typeSalle { get; set; }
        public string adresse { get; set; }
        public string codePostal { get; set; }
        public string ville { get; set; }
        public string etage { get; set; }
    }

}