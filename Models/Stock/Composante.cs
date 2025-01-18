using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.Stock
{
    public class Composante : Audit
    {
        [Required(ErrorMessage = "Le type de composante est obligatoire.")]
        public long TypeComposanteId { get; set; }
        public TypeComposante? TypeComposante { get; set; }
        [Required(ErrorMessage = "Le don associé à cette composante est obligatoire.")]
        public long DonId { get; set; }
        public Don? Don { get; set; }
        [Required(ErrorMessage = "Le volume obtenu pour cette composante est obligatoire.")]
        public int Volume { get; set; }
        public bool Statut { get; set; }
    }
}
