using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Collecte : Audit
    {
        [Required]
        [Display(Name = "Date Collecte")]
        public DateTime DateCollecte { get; set; }
        [Required]
        [Display(Name = "Centre")]
        public long CentreId { get; set; }
        public Centre? Centre { get; set; }
        [Required]
        public long Organisateur { get; set; }
        //CONECTED USER
    }
}