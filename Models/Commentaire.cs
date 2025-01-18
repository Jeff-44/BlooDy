using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Commentaire : Audit
    {
        [Required]
        public long DonateurId { get; set; }
        public Donateur? Donateur { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
