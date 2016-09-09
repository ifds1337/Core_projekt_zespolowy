using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjZesp.Models
{
    public class Klient
    {
        public int ID { get; set; }
        public string Klient_Email { get; set; }
        public string Klient_Imie { get; set; }
        public string Klient_Nazwisko { get; set; }
        public int Klient_NrTelefonu { get; set; }
    }
}
