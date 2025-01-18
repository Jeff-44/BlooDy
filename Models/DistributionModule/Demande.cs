using BlooDyWeb.Models.Stock;
using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{
    public class Demande : Audit
    {
        public long IdInstitutionSante { get; set; } //Automatique ID INSTITUTION CONNECTED USER
        public InstitutionSante? InstitutionSante { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer pour quel groupe sanguin vous effectuez cette demande.")]
        public string? GroupeSanguin { get; set; } // enum :
        [Required(ErrorMessage = "Vous devez indiquer pour quelle composante (Globules Rouge ect...) vous effectuez cette demande.")]
        public long IdTypeComposante { get; set; }
        public TypeComposante? TypeComposante { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer la quantite de cette composante que vous effectuez cette demande.")]
        public int Quantite { get; set; }
        public string? Statut { get; set; } //enum:
    }
}
