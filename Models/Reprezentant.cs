using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cretu_Alexandru_Project.Models
{
    public class Reprezentant
    {

        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z]+$"), Required, StringLength(100, MinimumLength = 3)]
        public string Prenume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z]+$"), Required, StringLength(100, MinimumLength = 3)]
        public string Nume { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            { return Prenume + " " + Nume; }
        }

        [RegularExpression(@"^[a-z]+$"), Required, StringLength(100, MinimumLength = 5)]
        public string? Adresa { get; set; }

        [RegularExpression(@"^[a-z]+@+[a-z]+$"), Required, StringLength(100, MinimumLength = 3)]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9]+$"), Required, StringLength(13, MinimumLength = 10)]
        public string Telefon { get; set; }
    }
}
