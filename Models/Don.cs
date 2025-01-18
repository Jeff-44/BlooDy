using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Don : Audit
    {
        [Required]
        [Display(Name = "Donateur")]
        public long DonateurId { get; set; }
        public Donateur? donateur { get; set; }
        [Required]
        [Display(Name = "Collecte")]
        public long CollecteId { get; set; }
        public Collecte? Collecte { get; set; }
        [Required]
        public int Volume { get; set; }
        public bool TestePositifPourMaladie { get; set; }

    }
}
