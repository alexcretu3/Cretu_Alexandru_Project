using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cretu_Alexandru_Project.Models
{
    public class Echipament
    {
        public int ID { get; set; }

        [DisplayName("Tip Echipament"), RegularExpression(@"^[a-z]+$"), Required, StringLength(30, MinimumLength = 3)]

        public string TipEchipament { get; set; }
        
        [RegularExpression(@"^[a-z]+$"), Required, StringLength(100, MinimumLength = 3)]
        public string Instrumente { get; set; }

        [Range(1, 500)]
        public decimal Pret { get; set; }
    }
}
