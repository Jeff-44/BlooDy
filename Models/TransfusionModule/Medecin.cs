namespace BlooDyWeb.Models.TransfusionModule
{
    public class Medecin : Audit
    {
        public string? Code { get; set; }
        public long PersonneId { get; set; }
        public Personne? Personne { get; set; }
    }
}
