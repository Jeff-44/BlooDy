using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Departement : Audit
    {
        [Required]
        public string Libelle { get; set; }
    }
}
