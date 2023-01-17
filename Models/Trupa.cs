using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cretu_Alexandru_Project.Models
{
    public class Trupa
    {

        public int ID { get; set; }

        [DisplayName("Nume Trupa")]
        [RegularExpression(@"^[A-Z]+[a-z]+$"), Required, StringLength(100, MinimumLength = 3)]
        public string NumeTrupa { get; set; }

        [DisplayName("Numar Persoane")]
        [Range(1, 10)]
        public int numarPersoane { get; set; }
        public int ReprezentantID { get; set; }
        public Reprezentant? Reprezentant { get; set; }
    }
}
