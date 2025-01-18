namespace BlooDyWeb.Models.DistributionModule
{
    public class LogDistribution : Audit
    {
        public long IdDistribution { get; set; }
        public string? Action { get; set; }
        public DateTime? TimeStamp { get; set; } //a reviser TimeStamp
    }
}
