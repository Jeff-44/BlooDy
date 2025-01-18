using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{
    public class Chauffeur : Audit
    {
        public long PersonneId { get; set; }
        [Required(ErrorMessage="Vous devez fournir les informations nécéssaires pour ajouter un nouveau chauffeur.")]
        public Personne? Personne { get; set; }
        public string? Code { get; set; }
        [Required(ErrorMessage = "Vous devez fournir le Centre auquel ce chauffeur sera affecté.")]
        public long CentreId { get; set; }
        public Centre? Centre { get; set; }
    }
}