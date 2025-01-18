using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.TransfusionModule
{
    public class Beneficiaire : Audit
    {
        public string? Code { get; set; }
        public long PersonneId { get; set; }
        public Personne? Personne { get; set; }
        [Required(ErrorMessage = "Il faut renseigner le groupe sanguin du bénéficiaire.")]
        public string? GroupeSanguin { get; set; }
        public string? HistoriqueMedical { get; set; }
        public long PersonneContactId { get; set; }
    }
}
