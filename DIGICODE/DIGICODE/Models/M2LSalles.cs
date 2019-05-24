using System;
using System.Collections.Generic;
using System.Text;

namespace DIGICODE.Models
{
   /* public class RootObject
    {
        public List<M2LSalles> M2LSalles { get; set; }
    }*/

    public class M2LSalles
    {
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
