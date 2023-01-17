using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Cretu_Alexandru_Project.Models
{
    public class Rezervare
    {
        public int ID { get; set; }

        public int SalaID { get; set; }
        public Sala? Sala { get; set; }

        public int TrupaID { get; set; }
        public Trupa? Trupa { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime DataInceput { get; set; }

        [BindProperty, DataType(DataType.Time)]
        public DateTime OraInceput { get; set; }

        [DisplayName("Tip Echipament")]
        public int EchipamentId { get; set; } 
        public Echipament? Echipament { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Timp { get; set; }

        public decimal Pret { get; set; }  
    }
}
