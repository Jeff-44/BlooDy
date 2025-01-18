using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Models.Stock;
using System.Net;

namespace BlooDyWeb.Models.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<Collecte>? collectes { get; set; } = new List<Collecte>();
        public IEnumerable<Donateur>? Donneurs { get; set; } = new List<Donateur>();
        public IEnumerable<Don>? Dons { get; set; } = new List<Don>();
        public IEnumerable<Centre>? centres { get; set; } = new List<Centre>();
        public IEnumerable<ExamenMedical>? dossiers { get; set; } = new List<ExamenMedical>();
        public IEnumerable<Composante>? composantes { get; set; } = new List<Composante>();
        public IEnumerable<Distribution>? distributions { get; set; } = new List<Distribution>();
        public IEnumerable<InstitutionSante>? hopitaux { get; set; } = new List<InstitutionSante>();
        public IEnumerable<Demande>? demandes { get; set; } = new List<Demande>();
        public IEnumerable<Chauffeur>? chauffeurs { get; set; } = new List<Chauffeur>();
        public IEnumerable<Transport>? livraisons { get; set; } = new List<Transport>();
    }
}
