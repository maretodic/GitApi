using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGit.Models
{
    public class PredmetModel
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string sifru { get; set; }
        public string kratak_opis { get; set; }
        public int godina { get; set; }
        public bool lab_vezbe { get; set; }    
    }
}