using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjZesp.Models
{
    public class Rezerwacje
    {
        public int ID { get; set; }
        public int Rez_ID_Pokoju { get; set; }
        public int Rez_ID_Klienta { get; set; }

        [Display(Name = "Rezerwacja od")]
        [DataType(DataType.Date)]
        public DateTime Rez_Od { get; set; }

        [Display(Name = "Rezerwacja do")]
        [DataType(DataType.Date)]
        public DateTime Rez_Do { get; set; }  
    }
}
