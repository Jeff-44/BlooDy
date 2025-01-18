using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{
    public class Distribution : Audit
    {
        [Required(ErrorMessage = "Vous devez indiquer pour quelle Demande vous effectuez cette Distribution.")]
        public long IdDemande { get; set; }
        public DateTime DateDistribution { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer la quantité de composante(s) demandée que vous affectez à cette Distribution.")]
        public int Quantite { get; set; }
        public int Statut { get; set; } = 0; //enum: En attente, ... assigner une valeur par defaut ex : 0
        public long IdContactDestinataire { get; set; }//  a ajouter
        public Personne? ContactDestinataire { get; set; } // a reviser
    }
}
