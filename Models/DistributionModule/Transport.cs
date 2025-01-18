using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{
    //FHIR CHAT: JUIN / JUILLET 2024
    public class Transport : Audit
    {
        [Required(ErrorMessage = "Vous devez indiquer pour quelle Distribution vouz effectuez cette Livraison.")]
        public long IdDistribution { get; set; }
        public Distribution? Distribution { get; set; }
        public string? ModeTransport { get; set; } // enum: 
        [Required(ErrorMessage = "Vous devez fournir le numéro de plaque du véhicule pour cette Livraison.")]
        public string? NumeroVehicule { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer le chauffeur affecté à ce véhicule pour cette Livraison.")]
        public long IdChauffeur { get; set; }
        public Chauffeur? Chauffeur { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer l'heure de départ du véhicule pour cette Livraison.")]
        public TimeOnly? HeureDepart { get; set; }
        public TimeOnly? HeureArrivee { get; set; }
        public string? Statut { get; set; } // enum: En Transit/Cours, Livré
        [Required(ErrorMessage = "Vous devez indiquer la température sous laquelle les composantes seront transportées.")]
        public int TemperatureTransport { get; set; }
        public TimeOnly HeureCheckTemperature { get; set; }

    }
}
