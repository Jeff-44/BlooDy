using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Audit
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Crée Par")]
        public string? CreePar { get; set; }
        [Display(Name = "Crée Le")]
        public DateTime? CreeLe { get; set; }
        [Display(Name = "Modifié Par")]
        public string?  ModifiePar { get; set; }
        [Display(Name = "Modifié Le")]
        public DateTime? ModifieLe { get; set; }    
    }
}
