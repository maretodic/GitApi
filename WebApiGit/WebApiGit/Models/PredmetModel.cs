using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGit.Models
{
    public class PredmetModel
    {
        public int ID { get; set; }
        public string Naziv_Predmeta { get; set; }
        public Nullable<decimal> Sifra_Predmeta { get; set; }
        public string Kratak_Opis { get; set; }
        public Nullable<sbyte> Godina { get; set; }
        public Nullable<bool> Lab_Vezbe { get; set; }
    }
}