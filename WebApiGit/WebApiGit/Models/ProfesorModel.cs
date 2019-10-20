using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGit.Models
{
    public class ProfesorModel
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Srednje_Ime { get; set; }
        public string Prezime { get; set; }
        public Nullable<System.DateTime> Datum_Rodjenja { get; set; }
        public Nullable<System.DateTime> Datum_Postavljenja { get; set; }
        public string Naziv_Predmeta { get; set; }
    }
}