using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.Stock
{
    public class TypeComposante : Audit
    {
        [Required(ErrorMessage = "Le nom de la composante est obligatoire.")]
        [Display(Name = "Nom Composante")]
        public string? Libelle { get; set; }
        [Required(ErrorMessage = "Le durée de vie de la composante est obligatoire.")]
        [Display(Name = "Durée de Vie (Nombre de jours)")]
        public int DureeVie { get; set; }
        [Required(ErrorMessage = "La température de conservation de la composante est obligatoire.")]
        [Display(Name = "Température (En degré C)")]
        public int Temperature { get; set; }
    }
}