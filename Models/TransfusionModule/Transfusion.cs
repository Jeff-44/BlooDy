using BlooDyWeb.Models.Stock;
using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.TransfusionModule
{
    public class Transfusion : Audit
    {
        [Required(ErrorMessage = "Il faut renseigner le groupe sanguin pour la Transfusion.")]
        [Display(Name = "Groupe Sanguin")]
        public string? GroupeSanguin { get; set; }
        [Required(ErrorMessage = "Il faut renseigner le bénéficiaire de cette Transfusion.")]
        public long BeneficiaireId { get; set; }
        public Beneficiaire? Beneficiaire { get; set; }
        [Required(ErrorMessage = "Il faut renseigner la Composante pour la Transfusion.")]
        public long ComposanteId { get; set; }
        public Composante? Composante { get; set; }
        [Required(ErrorMessage = "Il faut renseigner le médecin qui réalise cette Transfusion.")]
        public long MedecinId { get; set; }
        public Medecin? Medecin { get; set; }
        [Required(ErrorMessage = "Il faut renseigner l'institution de santé dans laquelle se réalise cette Transfusion.")]
        public long InstitutionSanteId { get; set; }
        public int Quantite { get; set; }
        public DateTime? DateTransfusion { get; set; }
        public bool Statut { get; set; }
        public string? Notes { get; set; }
    }
}
