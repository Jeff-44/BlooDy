using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Arrondissement : Audit
    {
        [Required]
        public string Libelle { get; set; }
        public int? DepartementId { get; set; }
        public Departement? departement { get; set; }
    }
}
