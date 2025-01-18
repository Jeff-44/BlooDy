using NuGet.Packaging.Signing;

namespace BlooDyWeb.Models.DistributionModule
{
    public class Notification : Audit
    {
        public long IdDistribution { get; set; }
        public string? Message { get; set; }
        public DateTime? TimeStamp { get; set; } //a reviser sur le TimeStamp
        public long IdDestinataire { get; set; }
        public Personne? Destinataire { get; set; } // a reviser sur l'entite Destinataire
    }
}
