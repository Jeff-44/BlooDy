using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlooDyWeb.Models
{
    public class ExamenMedical : Audit
    {
        [Display(Name = "Code")]
        [Required(ErrorMessage = "Le code du donateur est obligatoire.")]
        public long DonateurId { get; set; }
        public Donateur? Donateur { get; set; }
        //[Required(ErrorMessage = "Le niveau d'hémoglobine est obligatoire.")]
        //public DateTime Date { get; set; }
        [Required(ErrorMessage = "Le poids de la personne est obligatoire.")]
        [Range(10, 500, ErrorMessage = "Le poids de la personne doit être compris entre 10 et 500 kg")]
        public decimal Poids { get; set; }
        [Required(ErrorMessage = "Le pouls de la personne est obligatoire.")]
        [Range(10, 1000, ErrorMessage = "Le pouls est invalide. Il doit être compris entre 10 et 1000 bpm")]
        public int Pouls { get; set; }
        [Required(ErrorMessage = "La tension arterielle Systolique de la personne est obligatoire.")]
        public int TensionArterielleSystolique { get; set; }
        [Required(ErrorMessage = "La tension arterielle Diastolique de la personne est obligatoire.")]
        public int TensionArterielleDiastolique { get; set; }
        [Required(ErrorMessage = "Le niveau d'hémoglobine est obligatoire.")]
        [Range(0.0, 20.0, ErrorMessage = "Le niveau d'hémoglobine doit être compris entre 0.0 et 20.0.")]
        public decimal Hemoglobine { get; set; }
        public bool EtatDeSante { get; set; }
        
    }
}
