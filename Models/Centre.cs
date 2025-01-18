using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Centre : Audit
    {
        [Display(Name = "Code Centre")]
        public string? Code { get; set; }
        [Required]
        [Display(Name = "Nom Centre")]
        public string NomCentre { get; set; }
        [Required]
        [Display(Name = "Type Centre")]
        public string TypeCentre { get; set; }
        //FIXE OU MOBILE
        [Display(Name = "Responsable")]
        public long PersonneResponsableId { get; set; }
        //UTILISATEURS CLES: ADMIN, PERSONNEL DE LA CRH
        [Required]
        [Display(Name = "Ville")]
        public long VilleId { get; set; }
    }
}