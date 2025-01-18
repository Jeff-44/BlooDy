using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{
    public class InstitutionSante : Audit
    {
        public string? Code { get; set; }
        [Required(ErrorMessage = "Vous devez fournir le nom de l'institution.")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Vous devez indiquer la Catégorie de L'institution (Hopital, Centre de Santé, ect...).")]
        public string? Categorie { get; set; } //enum: Hopital, Centre de Sante, Dispensaire
        [Required(ErrorMessage = "Vous devez fournir l'adresse de l'institution.")]
        public string? Adresse { get; set; }
        [Required(ErrorMessage = "Vous devez fournir le telephone de l'institution.")]
        public string? Telephone { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer la ville dans laquelle se trouve cette institution.")]
        public string? Email { get; set; }
        public long? IdVille { get; set; }
        public bool Statut { get; set; } //enum: Actif, Inactif
    }
}