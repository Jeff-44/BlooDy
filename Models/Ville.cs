using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Ville : Audit
    {
        [Required]
        public string Libelle { get; set; }
        public int? ArrondissementId { get; set; }
    }
}
