using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models
{
    public class Donateur : Audit
    {
        [Display(Name = "Code Donateur")]
        public string? Code { get; set; }
        public long? PersonneId { get; set; }
        public Personne? Personne { get; set; }
        [Display(Name = "Groupe Sanguin")]
        public string? GroupeSanguin { get; set; }
        public long? PersonneDeContactId { get; set; }
        [Display(Name = "Personne de Contact")]
        public Personne? PersonneDeContact { get; set; }
    }
}
