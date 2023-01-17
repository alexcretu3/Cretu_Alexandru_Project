using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cretu_Alexandru_Project.Models
{
    public class Sala
    {
        public int ID { get; set; }
        [DisplayName("Nume Sala")]
        [RegularExpression(@"^[a-z]+$"), Required, StringLength(20, MinimumLength = 3)]
        public string NumeSala { get; set; }
        [RegularExpression(@"^[a-z]+$"), Required, StringLength(50, MinimumLength = 3)]
        public string Locatie { get; set; }

        [DisplayName("Suprafata (m2)")]
        [RegularExpression(@"^[0-9]+$"), Required, StringLength(10, MinimumLength = 1)]
        public string Suprafata { get; set; }

        [DisplayName("Pret (RON)")]
        [Range(1, 500)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
    }
}
